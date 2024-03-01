namespace AuthorProblem
{
    [Author("Victor")]
    public class StartUp
    {
        [Author("George")]
        [Author("Bella")]
        static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [Author("Steven")]
        public static void CustomMethod()
        {
        }

        [Author("Sofia")]
        private static void PrivateMethod()
        {

        }
    }
}
