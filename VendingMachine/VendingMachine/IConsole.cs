namespace VendingMachine
{
    public interface IConsole
    {
        string ReadLine();
        void WriteLine(string message);
        string GetLastMessageDisplayed();
    }
}