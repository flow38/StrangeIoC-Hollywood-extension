
using strange.extensions.hollywood.api;

namespace strange.extensions.hollywood.impl
{
    public abstract class AbstractService
    {
        [Inject]
        public IStartDirectorsSignal StartDirectors { get; set; }
    }
}
