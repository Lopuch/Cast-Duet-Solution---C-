class Program
    {
        int steps = 0;
        List<List<Position>> CorrectPaths = new List<List<Position>>();

        static void Main(string[] args)
        {
            var program = new Program();
        }

        public Program()
        {
            // START HERE
            var start = new Position(Position.Cells.Outside, Position.Cells.i, Position.Directions.Down); // First ring
            //var start = new Position(Position.Cells.Outside, Position.Cells.i, Position.Directions.Up); // Second ring
            // START HERE

            Step(start, new List<Position>());

            Debug.WriteLine($"Steps: {steps}");

            Debug.WriteLine("Shortest path: ");
            PrintPath(CorrectPaths.OrderBy(x => x.Count).First());

        }

        void Step(Position position, List<Position> path)
        {
            steps++;

            // I was here before -> I won't run in circles
            if (path.Any(x => x.Body == position.Body && x.Gap == position.Gap && x.Direction == position.Direction))
            {
                return;
            }

            path.Add(position);


            if (position.Body == Position.Cells.Outside && position.Gap == Position.Cells.Outside)
            {
                CorrectPaths.Add(path);
                PrintPath(path);
                return; // PATH FOUND!!!
            }

            bool didMove = false;

            var bunky = (Position.Cells[])Enum.GetValues(typeof(Position.Cells));
            foreach (Position.Cells bunkaProMezeru in bunky)
            {
                var newPosition = new Position(position.Body, bunkaProMezeru, position.Direction);
                if (CanMoveHere(position, newPosition))
                {
                    Step(newPosition, path.ToList());
                    didMove = true;
                }
            }

            if (didMove == false) // DEBUG ONLY
            {
                //Can move only if turns 180° (or there is a bug in a code)
            }

            // Turn 180°  (I can turn anytime)
            var turnedPosition = new Position(position.Gap, position.Body, position.Direction == Position.Directions.Down ? Position.Directions.Up : Position.Directions.Down);
            Step(turnedPosition, path.ToList());





        }

        public void PrintPath(List<Position> path)
        {
            Debug.WriteLine("----");
            path.ForEach(x => Debug.WriteLine(x.ToString()));
            Debug.WriteLine("_   _");
            Debug.WriteLine("");
        }

        public bool CanMoveHere(Position from, Position to)
        {
            #region for simplicity

            const Position.Directions up = Position.Directions.Up;
            const Position.Directions down = Position.Directions.Down;

            const Position.Cells a = Position.Cells.a;
            const Position.Cells b = Position.Cells.b;
            const Position.Cells c = Position.Cells.c;
            const Position.Cells d = Position.Cells.d;
            const Position.Cells e = Position.Cells.e;
            const Position.Cells f = Position.Cells.f;
            const Position.Cells g = Position.Cells.g;
            const Position.Cells h = Position.Cells.h;
            const Position.Cells i = Position.Cells.i;
            const Position.Cells outside = Position.Cells.Outside;

            #endregion

            // Turn 180°
            if (to.Body == from.Gap && to.Gap == from.Body && to.Direction != from.Direction)
            {
                return true;
            }

            switch (to.Gap)
            {
                case a:
                    if (from.Direction == up && from.Body == e && from.Gap == d) return true;
                    if (from.Direction == up && from.Body == b && from.Gap == d) return true;
                    if (from.Direction == up && from.Body == outside && from.Gap == d) return true;
                    //
                    if (from.Direction == down && from.Body == b && from.Gap == outside) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == outside) return true;

                    if (from.Direction == down && from.Body == e && from.Gap == b) return true;
                    if (from.Direction == down && from.Body == d && from.Gap == b) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == b) return true;
                    break;

                case b:
                    if (from.Direction == up && from.Body == f && from.Gap == c) return true;
                    if (from.Direction == up && from.Body == e && from.Gap == c) return true;
                    if (from.Direction == up && from.Body == outside && from.Gap == c) return true;

                    if (from.Direction == up && from.Body == d && from.Gap == e) return true;
                    if (from.Direction == up && from.Body == a && from.Gap == e) return true;

                    if (from.Direction == up && from.Body == f && from.Gap == e) return true;
                    if (from.Direction == up && from.Body == c && from.Gap == e) return true;
                    //
                    if (from.Direction == down && from.Body == a && from.Gap == outside) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == outside) return true;

                    if (from.Direction == down && from.Body == c && from.Gap == outside) return true;

                    if (from.Direction == down && from.Body == d && from.Gap == a) return true;
                    if (from.Direction == down && from.Body == e && from.Gap == a) return true;

                    if (from.Direction == down && from.Body == f && from.Gap == e) return true;
                    if (from.Direction == down && from.Body == c && from.Gap == e) return true;
                    break;

                case c:
                    if (from.Direction == up && from.Body == e && from.Gap == b) return true;
                    if (from.Direction == up && from.Body == f && from.Gap == b) return true;
                    if (from.Direction == up && from.Body == outside && from.Gap == b) return true;
                    //
                    if (from.Direction == down && from.Body == b && from.Gap == outside) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == outside) return true;

                    if (from.Direction == down && from.Body == f && from.Gap == outside) return true;
                    break;

                case d:
                    if (from.Direction == up && from.Body == b && from.Gap == a) return true;
                    if (from.Direction == up && from.Body == e && from.Gap == a) return true;
                    if (from.Direction == up && from.Body == outside && from.Gap == a) return true;

                    if (from.Direction == up && from.Body == h && from.Gap == e) return true;
                    if (from.Direction == up && from.Body == g && from.Gap == e) return true;

                    if (from.Direction == up && from.Body == b && from.Gap == e) return true;
                    if (from.Direction == up && from.Body == a && from.Gap == e) return true;
                    //
                    if (from.Direction == down && from.Body == g && from.Gap == outside) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == outside) return true;

                    if (from.Direction == down && from.Body == a && from.Gap == outside) return true;

                    if (from.Direction == down && from.Body == outside && from.Gap == g) return true;

                    if (from.Direction == down && from.Body == b && from.Gap == e) return true;
                    if (from.Direction == down && from.Body == a && from.Gap == e) return true;
                    break;

                case e:
                    if (from.Direction == up && from.Body == c && from.Gap == b) return true;
                    if (from.Direction == up && from.Body == f && from.Gap == b) return true;

                    if (from.Direction == up && from.Body == a && from.Gap == b) return true;
                    if (from.Direction == up && from.Body == d && from.Gap == b) return true;

                    if (from.Direction == up && from.Body == i && from.Gap == f) return true;
                    if (from.Direction == up && from.Body == h && from.Gap == f) return true;

                    if (from.Direction == up && from.Body == c && from.Gap == f) return true;
                    if (from.Direction == up && from.Body == b && from.Gap == f) return true;

                    if (from.Direction == up && from.Body == g && from.Gap == h) return true;
                    if (from.Direction == up && from.Body == d && from.Gap == h) return true;

                    if (from.Direction == up && from.Body == i && from.Gap == h) return true;
                    if (from.Direction == up && from.Body == f && from.Gap == h) return true;

                    if (from.Direction == up && from.Body == a && from.Gap == d) return true;
                    if (from.Direction == up && from.Body == b && from.Gap == d) return true;

                    if (from.Direction == up && from.Body == g && from.Gap == d) return true;
                    if (from.Direction == up && from.Body == h && from.Gap == d) return true;
                    //
                    if (from.Direction == down && from.Body == c && from.Gap == b) return true;
                    if (from.Direction == down && from.Body == f && from.Gap == b) return true;

                    if (from.Direction == down && from.Body == a && from.Gap == d) return true;
                    if (from.Direction == down && from.Body == b && from.Gap == d) return true;

                    if (from.Direction == down && from.Body == i && from.Gap == h) return true;
                    if (from.Direction == down && from.Body == f && from.Gap == h) return true;

                    if (from.Direction == down && from.Body == g && from.Gap == h) return true;
                    if (from.Direction == down && from.Body == d && from.Gap == h) return true;

                    if (from.Direction == down && from.Body == i && from.Gap == f) return true;
                    if (from.Direction == down && from.Body == h && from.Gap == f) return true;
                    break;

                case f:
                    if (from.Direction == up && from.Body == outside && from.Gap == i) return true;

                    if (from.Direction == up && from.Body == b && from.Gap == e) return true;
                    if (from.Direction == up && from.Body == c && from.Gap == e) return true;

                    if (from.Direction == up && from.Body == h && from.Gap == e) return true;
                    if (from.Direction == up && from.Body == i && from.Gap == e) return true;
                    //
                    if (from.Direction == down && from.Body == h && from.Gap == e) return true;
                    if (from.Direction == down && from.Body == i && from.Gap == e) return true;

                    if (from.Direction == down && from.Body == c && from.Gap == outside) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == outside) return true;

                    if (from.Direction == down && from.Body == i && from.Gap == outside) return true;
                    break;

                case g:
                    if (from.Direction == up && from.Body == e && from.Gap == h) return true;
                    if (from.Direction == up && from.Body == d && from.Gap == h) return true;
                    if (from.Direction == up && from.Body == outside && from.Gap == h) return true;

                    if (from.Direction == up && from.Body == h && from.Gap == outside) return true;
                    if (from.Direction == up && from.Body == outside && from.Gap == outside) return true;
                    //
                    if (from.Direction == down && from.Body == outside && from.Gap == d) return true;

                    if (from.Direction == down && from.Body == d && from.Gap == outside) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == outside) return true;

                    if (from.Direction == down && from.Body == h && from.Gap == outside) return true;

                    break;

                case h:
                    if (from.Direction == up && from.Body == f && from.Gap == e) return true;
                    if (from.Direction == up && from.Body == i && from.Gap == e) return true;

                    if (from.Direction == up && from.Body == d && from.Gap == e) return true;
                    if (from.Direction == up && from.Body == g && from.Gap == e) return true;

                    if (from.Direction == up && from.Body == g && from.Gap == outside) return true;
                    if (from.Direction == up && from.Body == outside && from.Gap == outside) return true;

                    if (from.Direction == up && from.Body == d && from.Gap == g) return true;
                    if (from.Direction == up && from.Body == e && from.Gap == g) return true;
                    if (from.Direction == up && from.Body == outside && from.Gap == g) return true;
                    //
                    if (from.Direction == down && from.Body == d && from.Gap == e) return true;
                    if (from.Direction == down && from.Body == g && from.Gap == e) return true;

                    if (from.Direction == down && from.Body == f && from.Gap == e) return true;
                    if (from.Direction == down && from.Body == i && from.Gap == e) return true;

                    if (from.Direction == down && from.Body == f && from.Gap == i) return true;
                    if (from.Direction == down && from.Body == e && from.Gap == i) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == i) return true;
                    break;

                case i:
                    if (from.Direction == up && from.Body == outside && from.Gap == f) return true;
                    //
                    if (from.Direction == down && from.Body == e && from.Gap == h) return true;
                    if (from.Direction == down && from.Body == f && from.Gap == h) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == h) return true;
                    break;

                case outside:
                    if (from.Direction == up && from.Body == g && from.Gap == h) return true;
                    if (from.Direction == up && from.Body == outside && from.Gap == h) return true;

                    if (from.Direction == up && from.Body == h && from.Gap == g) return true;
                    if (from.Direction == up && from.Body == outside && from.Gap == g) return true;


                    //
                    if (from.Direction == down && from.Body == b && from.Gap == c) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == c) return true;

                    if (from.Direction == down && from.Body == a && from.Gap == b) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == b) return true;

                    if (from.Direction == down && from.Body == c && from.Gap == b) return true;

                    if (from.Direction == down && from.Body == b && from.Gap == a) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == a) return true;

                    if (from.Direction == down && from.Body == g && from.Gap == d) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == d) return true;

                    if (from.Direction == down && from.Body == a && from.Gap == d) return true;

                    if (from.Direction == down && from.Body == d && from.Gap == g) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == g) return true;

                    if (from.Direction == down && from.Body == h && from.Gap == g) return true;

                    if (from.Direction == down && from.Body == c && from.Gap == f) return true;
                    if (from.Direction == down && from.Body == outside && from.Gap == f) return true;

                    if (from.Direction == down && from.Body == i && from.Gap == f) return true;

                    if (from.Direction == down && from.Body == f && from.Gap == c) return true;
                    break;
            }


            return false;
        }


        public class Position
        {
            public override string ToString()
            {
                return Enum.GetName(typeof(Cells), Body) + " | " + Enum.GetName(typeof(Cells), Gap) + " | " + Enum.GetName(typeof(Directions), Direction);
            }

            public enum Directions { Up, Down }
            public enum Cells { Outside, a, b, c, d, e, f, g, h, i };
            public Cells Body { get; set; }
            public Cells Gap { get; set; }
            public Directions Direction { get; set; }

            public Position(Cells body, Cells gap, Directions direction)
            {
                Body = body;
                Gap = gap;
                Direction = direction;
            }
        }

    }
