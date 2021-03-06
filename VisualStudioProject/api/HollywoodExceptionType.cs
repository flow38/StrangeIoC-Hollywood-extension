﻿
namespace strange.extensions.hollywood.api
{
    public enum HollywoodExceptionType
    {
        /// <summary>
        /// Dispatch when user have not bind LaunchAppSignal Class to a command in its 
        /// context class  mapBindings method override
        /// </summary>
        LaunchAppSignalIsNotBindToACommand,
        /// <summary>
        /// During Director binding to Actor, Director instance is set on Actor but only once...
        /// </summary>
        DirectorIsAlreadyDefine,
        /// <summary>
        /// while accessing getter or setter Director instance on an Actor which is not supposed to have any attached Director instance .
        /// </summary>
        ActorIsAnAloneActorInstance
    }
}
