using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Work
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(graphPanel.Width, graphPanel.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            graphPanel.Image = bm;
            barricades = new List<Barricade>();
            graph = new List<Node>();
            all_path = new List<Path>();
            random = new Random();
            cancelletionTokenSource = new CancellationTokenSource();
        }

        private bool isButtonPaintOn = false;
        bool isRobot = false;
        PictureBox robot;
        PictureBox goal;
        bool isBarricade = false;
        bool isGoal = false;
        Bitmap bm;
        bool isDraw = false;
        private Graphics g;
        Point px, py;
        Point pointR, pointG;
        Pen p = new Pen(Color.Black, 1);
        int x, y, cX, cY, sX, sY;
        List<Barricade> barricades;
        List<Node> graph;
        List<Path> all_path;
        Dictionary<Node, Node> path;
        Random random;
        CancellationTokenSource cancelletionTokenSource;
        int count_nodes;
        Node currentNode;
        private void buttonPaint_Click(object sender, EventArgs e)
        {
            if (isButtonPaintOn)
            {
                panelPaintInstruments.Visible = false;
                isButtonPaintOn = false;
                buttonLearning.Enabled = true;
                buttonStart.Enabled = true;
                isRobot = isGoal = isBarricade = false;
                buttonBarricade.BackColor = Color.FloralWhite;
                buttonGoal.BackColor = Color.FloralWhite;
                buttonRobot.BackColor = Color.FloralWhite;

                buttonPaint.Text = "Малювати";

            }
            else
            {
                panelPaintInstruments.Visible = true;
                isButtonPaintOn = true;
                buttonLearning.Enabled = false;
                buttonStart.Enabled = false;
                buttonPaint.Text = "Завершити малювання";
            }
        }

        private void buttonRobot_Click(object sender, EventArgs e)
        {
            if (isRobot)
            {
                isRobot = false;
                buttonRobot.BackColor = Color.FloralWhite;
            }
            else
            {
                isRobot = true;
                if (isGoal || isBarricade)
                {
                    isGoal = false;
                    isBarricade = false;

                    if (buttonGoal.BackColor == Color.LightGray)
                        buttonGoal.BackColor = Color.FloralWhite;
                    if (buttonBarricade.BackColor == Color.LightGray)
                        buttonBarricade.BackColor = Color.FloralWhite;

                }
                buttonRobot.BackColor = Color.LightGray;
            }
        }

        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (isDraw)
            {
                if (isBarricade)
                {
                    g.FillRectangle(Brushes.Black, cX, cY, sX, sY);
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            robot = new PictureBox
            {
                Name = "robot",
                Size = new Size(40, 40),
                BackgroundImage = Image.FromFile("D:\\Учеба-1\\КУРСОВА\\Course_work\\Course_Work\\Resources\\robot.png"),
                BackgroundImageLayout = ImageLayout.Zoom
            };
            goal = new PictureBox
            {
                Name = "goal",
                Size = new Size(40, 40),
                BackgroundImage = Image.FromFile("D:\\Учеба-1\\КУРСОВА\\Course_work\\Course_Work\\Resources\\cancel.png"),
                BackgroundImageLayout = ImageLayout.Zoom
            };
        }

        private void buttonLearning_Click(object sender, EventArgs e)
        {
            buttonPaint.Enabled = false;
            //ініціалізація точок
            count_nodes = 100;
            int x = 0, y = 0;
            int max_x = graphPanel.Width - 20;
            int max_y = graphPanel.Height - 20;
            int index = 1;
            graph.Add(new Node(0, pointR, 1));
            bool isInBarricade = false;
            do
            {
                x = random.Next(max_x);
                y = random.Next(max_y);
                isInBarricade = false;
                foreach(Barricade baricade in barricades)
                {
                    if(x + 20 >= baricade.startPoint.X && x - 20 <= baricade.startPoint.X + baricade.width
                        && y + 20 >= baricade.startPoint.Y && y - 20 <= baricade.startPoint.Y + baricade.height)
                    {
                        isInBarricade = true;
                    }
                    
                }
                if (x + 20 >= pointR.X - 20 && x - 20 <= pointR.X + 20
                    && y + 20 >= pointR.Y - 20 && y - 20 <= pointR.Y + 20)
                    isInBarricade = true;
                if (x + 20 >= pointG.X - 20 && x - 20<= pointG.X + 20
                    && y + 20 >= pointG.Y - 20 && y - 20 <= pointG.Y + 20)
                    isInBarricade = true;
                foreach(Node n in graph)
                {
                    if (x + 20 >= n.x && x <= n.x + 20
                    && y + 20 >= n.y - 20 && y <= n.y + 20)
                        isInBarricade = true;
                }
                if (isInBarricade)
                    continue;
                Point p = new Point(x, y);
                int group_id = random.Next(0, 2);
                Node new_node = new Node(index, p, group_id);
                graph.Add(new_node);
                graphPanel.Controls.Add(new_node.pictureBox);
                toolTip1.SetToolTip(graph[graph.Count - 1].pictureBox, "id:" + graph[graph.Count - 1].id
                    + "\n(" + graph[graph.Count - 1].x + ";" + graph[graph.Count - 1].y +
                    ")\ngroup:" + graph[graph.Count - 1].group_id);
                index++;
            } while (index < count_nodes);
            graph.Add(new Node(index, pointG, 1));
            //з'єднання
            int count_neighbours = 5;
            double distance = 0.0;
            double min_distance = 0.0;
            int min_index = 0;
            int count_group_1 = 0, count_group_2 = 0;
            List<Node> neighbours = new List<Node>(count_neighbours);
            for (int i = 0; i < graph.Count; i++)
            {
                for (int j = 0; j < count_neighbours; j++)
                {
                    for (int k = 0; k < graph.Count; k++)
                    {
                        if (i != j)
                        {
                            if (!neighbours.Contains(graph[k]))
                            {
                                distance = Math.Sqrt(Math.Pow(graph[i].x - graph[k].x, 2) + Math.Pow(graph[i].y - graph[k].y, 2));
                                if (k == 1 || min_distance > distance)
                                {
                                    min_distance = distance;
                                    min_index = k;
                                }
                            }
                        }
                    }
                    if (!checkIfInCollisionWithBarricade(graph[i], graph[min_index]))
                        neighbours.Add(graph[min_index]);
                    if (graph[min_index].group_id == 1)
                        count_group_2++;
                    else
                        count_group_1++;

                    min_distance = 0;
                    distance = 0;
                }
                foreach(Node n in neighbours)
                {
                    g.DrawLine(p, graph[i].x + 10, graph[i].y + 10, n.x + 10, n.y + 10);
                    all_path.Add(new Path(graph[i], n, Math.Sqrt(Math.Pow(graph[i].x - n.x, 2) + Math.Pow(graph[i].y - n.y, 2))));
                }
                count_group_1 = count_group_2 = 0;
                neighbours.Clear();
            }
            graphPanel.Refresh();
            buttonLearning.Enabled = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            AStar star_search = new AStar(all_path, graph[0], graph.Last());
            path = star_search.cameFrom;
            int index = 0;
            var node_current = path.First();
            int current_id = count_nodes;
            Dictionary<Node, Node> best_path = new Dictionary<Node, Node>();
            foreach (var n in path.Reverse())
            {
                if (n.Key.id != current_id)
                    path.Remove(n.Key);
                else
                {
                    current_id = n.Value.id;
                }
            }
            foreach (var n in path)
            {
                
                if(index == 0)
                    label1.Text += "\n\r(" + n.Value.id + ";" + n.Key.id + ")->";
                else
                    label1.Text += "(" + n.Value.id + ";" + n.Key.id + ")->";
                if ((index + 1) % 5 == 0)
                    label1.Text += "\n\r";

                index++;
            }
            buttonContinue.Enabled = true;
            buttonStop.Enabled = true;
        }

        private async void buttonContinue_Click(object sender, EventArgs e)
        {
            if (cancelletionTokenSource.IsCancellationRequested)
            {
                cancelletionTokenSource.Dispose();
                cancelletionTokenSource = new CancellationTokenSource();
            }
            
            CancellationToken token = cancelletionTokenSource.Token;
            robot.BringToFront();
            if(currentNode.Equals(null))
                currentNode = graph[0];
            bool isEnd = false;
            foreach (var n in path)
            {
                if (currentNode.id != n.Value.id)
                    continue;
                if (token.IsCancellationRequested)
                    break;
                await Task.Delay(1000);
                robot.Left = n.Key.x;
                robot.Top = n.Key.y;
                currentNode = n.Key;
                if (n.Key.id == count_nodes)
                    isEnd = true;
            }
            if (isEnd)
            {
                buttonStart.Enabled = false;
                buttonContinue.Enabled = false;
                buttonStop.Enabled = false;
                buttonPaint.Enabled = true;
                cancelletionTokenSource = null;
                
            }
            
        }

        private async void buttonStop_Click(object sender, EventArgs e)
        {
            await Task.Run(() => cancelletionTokenSource.Cancel());
            
        }


        private bool checkIfInCollisionWithBarricade(Node n1, Node n2)
        {
            //розділимо лінію між двома точками на 50 точок і будемо перевіряти чи входить хоч одна точка в цей проміжок
            double iter_x = (n2.x - n1.x) / 50;
            double iter_y = (n2.y - n1.y) / 50;
            int iter = 1;
            double x = n1.x + 10, y = n1.y + 10;
            do
            {
                foreach (Barricade b in barricades)
                {
                    if (x >= b.startPoint.X * 1.0 && x <= (b.startPoint.X + b.width) * 1.0
                        && y >= b.startPoint.Y * 1.0 && y <= (b.startPoint.Y + b.height) * 1.0)
                    {
                        //label1.Text += "\n\r" + n1.id + "-" + n2.id + ": (" + x + ";" + y + ")";
                        return true;
                    }
                }
                iter++;
                x += iter_x;
                y += iter_y;
            } while (iter != 50);
            
            return false;
        }

        private void buttonBarricade_Click(object sender, EventArgs e)
        {
            if (isBarricade)
            {
                isBarricade = false;
                buttonBarricade.BackColor = Color.FloralWhite;
            }
            else
            {
                isBarricade = true;
                if (isGoal || isRobot)
                {
                    isGoal = false;
                    isRobot = false;

                    if (buttonGoal.BackColor == Color.LightGray)
                        buttonGoal.BackColor = Color.FloralWhite;
                    if (buttonRobot.BackColor == Color.LightGray)
                        buttonRobot.BackColor = Color.FloralWhite;

                }
                buttonBarricade.BackColor = Color.LightGray;
            }
        }

        private void buttonGoal_Click(object sender, EventArgs e)
        {
            if (isGoal)
            {
                isGoal = false;
                buttonGoal.BackColor = Color.FloralWhite;
            }
            else
            {
                isGoal = true;
                if (isBarricade || isRobot)
                {
                    isBarricade = false;
                    isRobot = false;

                    if (buttonBarricade.BackColor == Color.LightGray)
                        buttonBarricade.BackColor = Color.FloralWhite;
                    if (buttonRobot.BackColor == Color.LightGray)
                        buttonRobot.BackColor = Color.FloralWhite;

                }
                buttonGoal.BackColor = Color.LightGray;
            }
        }

        private void graphPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if(!buttonStart.Enabled)
                isDraw = true;
            py = e.Location;
            cX = e.X;
            cY = e.Y;
        }

        private void graphPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraw)
            {
                
            }
            graphPanel.Refresh();
            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void graphPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDraw = false;

            if (isBarricade)
            {
                g.FillRectangle(Brushes.Black, cX, cY, sX, sY);
                Point p = new Point(cX, cY);
                Barricade b = new Barricade(p, sX, sY);
                barricades.Add(b);
                label1.Text += "\n\r" + b.GetInfo();
            }
            if (isRobot)
            {
                pointR = new Point(cX - 20, cY - 20);
                robot.Location = pointR;
                graphPanel.Controls.Add(robot);
                graphPanel.Refresh();
            }
            if (isGoal)
            {
                pointG = new Point(cX - 20, cY - 20);
                goal.Location = pointG;
                graphPanel.Controls.Add(goal);
                graphPanel.Refresh();
            }
        }

        private void buttonEraser_Click(object sender, EventArgs e)
        {
            graphPanel.Controls.Remove(robot);
            graphPanel.Controls.Remove(goal);
            robot.Dispose();
            goal.Dispose();
            if(graph.Count > 0)
            {
                foreach (var node in graph)
                {
                    graphPanel.Controls.Remove(node.pictureBox);
                    node.pictureBox.Dispose();
                }
                graph.Clear();
            }
            if(barricades!= null)
                barricades.Clear();
            if(all_path != null) 
                all_path.Clear();
            g.FillRectangle(Brushes.White, 0, 0, graphPanel.Width, graphPanel.Height);
            random = new Random();
            graphPanel.Refresh();
            if(path != null)
                path.Clear();
            robot = new PictureBox
            {
                Name = "robot",
                Size = new Size(40, 40),
                BackgroundImage = Image.FromFile("D:\\Учеба-1\\КУРСОВА\\Course_work\\Course_Work\\Resources\\robot.png"),
                BackgroundImageLayout = ImageLayout.Zoom
            };
            goal = new PictureBox
            {
                Name = "goal",
                Size = new Size(40, 40),
                BackgroundImage = Image.FromFile("D:\\Учеба-1\\КУРСОВА\\Course_work\\Course_Work\\Resources\\cancel.png"),
                BackgroundImageLayout = ImageLayout.Zoom
            };
            label1.Text = "Перешкоди:";
        }

        
    }
}

public class Barricade
{
    public Point startPoint;

    public int width;
    public int height;

    public Barricade(Point point, int width, int height)
    {
        this.startPoint = point;
        this.width = width;
        this.height = height;
    }
    public string GetInfo()
    {
        return "(" + startPoint.X + ";" + startPoint.Y + ") h:" + height + " w: " + width;
    }
}

public struct Node : IComparer<Node>
{
    public PictureBox pictureBox;
    public int id;
    private const string img_path = "D:\\Учеба-1\\КУРСОВА\\Course_work\\Course_Work\\Resources\\record.png";
    public const int width = 20, height = 20;
    public int x, y;
    public int group_id;
    public Node(int id, Point location, int group)
    {
        this.id = id;
        pictureBox = new PictureBox()
        {
            Name = "node" + id,
            Location = location,
            BackgroundImage = new Bitmap(img_path),
            BackgroundImageLayout = ImageLayout.Zoom,
            Size = new Size(width, height)
            
        };
        
        x = location.X;
        y = location.Y;
        group_id = group;
    }

    public int Compare(Node n1, Node n2)
    {
        return (n1.x + n1.y).CompareTo(n2.x + n2.y);
    }
}

public struct Path : IComparer<Path>
{
    public Node node1, node2;
    public double distance;
    public Path(Node node1, Node node2, double distance)
    {
        this.node1 = node1;
        this.node2 = node2;
        this.distance = distance;
    }

    public int Compare(Path x, Path y)
    {
        return x.distance.CompareTo(y.distance);
    }
}

public class AStar
{
    public Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
    public Dictionary<Node, double> costSoFar = new Dictionary<Node, double>();

    static public double heuristic(Node p1, Node p2)
    {
        //Манхеттенська відстань
        return Math.Abs(p1.x - p2.x) + Math.Abs(p1.y - p2.y);
    }

    public AStar(List<Path> all_path, Node robot, Node goal)
    {
        var limit = new Dictionary<Node, double>();
        limit.Add(robot, 0);

        cameFrom[robot] = robot;
        costSoFar[robot] = 0;

        while (limit.Count > 0)
        {
            var current = limit.Aggregate((l, r) => l.Value < r.Value ? l : r);
            limit.Remove(current.Key);

            if (current.Key.id == goal.id)
            {
                break;
            }

            List<Path> neighbours_current = new List<Path>();

            foreach (var path in all_path)
            {
                if (path.node1.id == current.Key.id)
                    neighbours_current.Add(path);
            }

            foreach (var next in neighbours_current)
            {
                double new_cost = costSoFar[next.node1] + next.distance;
                if(!costSoFar.ContainsKey(next.node2) || new_cost < costSoFar[next.node2])
                {
                    costSoFar[next.node2] = new_cost;
                    double priority = new_cost + heuristic(next.node2, goal);
                    limit[next.node2] = priority;
                    cameFrom[next.node2] = next.node1;
                }

            }

            neighbours_current.Clear();
        }
    }

}
