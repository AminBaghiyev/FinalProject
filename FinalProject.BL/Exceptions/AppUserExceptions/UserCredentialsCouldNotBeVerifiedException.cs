namespace FinalProject.BL.Exceptions;

public class UserCredentialsCouldNotBeVerifiedException : Exception
{
    public UserCredentialsCouldNotBeVerifiedException(string message) : base(message) { }

    public UserCredentialsCouldNotBeVerifiedException() : base("Username or password is invalid!") { }
}
