namespace VendingMachine
{
    public class MockGetInput : IConsole
    {
        private string _lastMessageDisplayed;

        public string ReadLine()
        {
            return "";
        }

        public void WriteLine(string message)
        {
            _lastMessageDisplayed = message;
        }

        public string GetLastMessageDisplayed()
        {
            return _lastMessageDisplayed;
        }
    }
}