using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mission
{
    /// <summary>
    /// Time the mission started
    /// </summary>
    public float StartTime { get; set; }

    #region Events

    /// <summary>
    /// Called when a mission has been completed
    /// </summary>
    public event EventHandler MissionCompleted;
    private void OnMissionCompleted(MissionCompletedEventArgs e)
    {
        EventHandler Handler = MissionCompleted;
        Handler?.Invoke(this, e);
    }

    #endregion

    public Mission(float Time)
    {
        StartTime = Time;
    }
}
