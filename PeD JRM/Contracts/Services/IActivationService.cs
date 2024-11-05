namespace PeD_JRM.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
