using System;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.flushi.game
{
	public interface IExampleService
	{
		void Request(string url);
		IEventDispatcher dispatcher{get;set;}
	}
}

