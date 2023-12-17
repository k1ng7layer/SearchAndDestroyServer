namespace Services.LevelObjectProvider.Impl
{
    public class LevelObjectsHolder : ILevelObjectsHolder
    {
        public LevelObjectsHolder(CommonObjectsHolder commonObjectsHolder)
        {
            CommonObjectsHolder = commonObjectsHolder;
        }
        
        public CommonObjectsHolder CommonObjectsHolder { get; }
    }
}