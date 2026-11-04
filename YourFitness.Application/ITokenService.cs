using YourFitness.Domain;

namespace YourFitness.Application;

/* Contract on what TokenService must be able to do
 * Makes it easier to mock the service
 */
public interface ITokenService
{
    // Creates a signed token identifying the given user
    string CreateToken(User user);
}