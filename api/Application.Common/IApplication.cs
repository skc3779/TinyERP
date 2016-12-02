namespace App.Common
{
    public interface IApplication
    {
        void OnApplicationStarted();
        void OnApplicationEnded();
        void OnApplicationRequestStarted();
        void OnApplicationRequestEnded();
        void OnUnHandledError();
    }
}