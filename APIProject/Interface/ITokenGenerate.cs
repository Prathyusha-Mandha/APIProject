using APIProject.Model;

namespace APIProject.Interface
{
    public interface ITokenGenerate
    {
        public string GenerateToken(User user);
    }
}
