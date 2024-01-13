namespace Services.GameRoles
{
    public interface IGameRoleService
    {
        void InitializeRoles(int playerNum);
        bool TryGetGameRole(out EGameRole role);
    }
}