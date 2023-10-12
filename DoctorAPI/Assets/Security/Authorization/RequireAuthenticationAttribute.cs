namespace DoctorAPI.Assets.Security.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class RequireAuthenticationAttribute : Attribute
{
}