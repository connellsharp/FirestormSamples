namespace TodoBackend.Stems.Helpers
{
    internal static class AutoIncrement
    {
        private static int _todoId;

        public static int PopTodoId()
        {
            return _todoId++;
        }
    }
}