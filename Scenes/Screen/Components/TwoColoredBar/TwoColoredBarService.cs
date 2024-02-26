using KludgeBox;
using KludgeBox.Events;

namespace NeoVector;

[GameService]
public class TwoColoredBarService
{
	
	[GameEventListener]
	public void OnTwoColoredBarProcessEvent(TwoColoredBarProcessEvent twoColoredBarProcessEvent)
	{
		TwoColoredBar twoColoredBar = twoColoredBarProcessEvent.TwoColoredBar;
		twoColoredBar.UpperBar.CustomMinimumSize = Vec(twoColoredBar.Width * twoColoredBar.CurrentUpperValuePercent, 0);
		twoColoredBar.LowerBar.CustomMinimumSize = Vec(twoColoredBar.Width * twoColoredBar.CurrentLowerValuePercent, 0);
	}
}