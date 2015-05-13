using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2B0app
{
	public enum MyPage {
		None,
		SplashScreen,
		About,
		Home,
		Settings,
		Main,
		Holos,
		Logics,
		Panels,
		Sound,
		Music,
		Status
	}

    public enum Screen
    {
        Holos,
        Logics,
        Main,
        Panel,
        Sound
    }

	public enum R2Command 
	{
		/// <summary>
		/// Set the state of the unit.
		/// var mode=State
		/// State could be one of:
		/// Autonomous
		/// Shutdown
		/// </summary>
		State,
		Panel,
		Logics,
		PSI,
		/// <summary>
		/// Play a sound.
		/// var type=SoundType to play (whitle, ...)
		/// </summary>
		Sound,
		/// <summary>
		/// Play or Stop a music.
		/// var action=Play/Stop
		/// var id=Music to play
		/// </summary>
		Music,
		/// <summary>
		/// Request status of elements. 
		/// If no var, all elements.
		/// var element=ElementName
		/// </summary>
		Status
	}

}