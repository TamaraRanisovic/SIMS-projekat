using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace WebApi.Entities;

public class Checkpoint
{
    [Key]
    public int CheckpointId { get; set; }
    public string Name { get; set; }

    public CheckpointType Type { get; set; }

    public bool Status { get; set; }

    public List<Tourist> Tourists { get; set; }

    public Checkpoint() 
    {
        Tourists = new List<Tourist>();
    }

    public Checkpoint(int checkpointId, string name, CheckpointType type, bool status)
    {
        CheckpointId = checkpointId;
        Name = name;
        Type = type;
        Status = status;
        Tourists = new List<Tourist>();
    }

    public override string ToString()
    {
        return $"CheckPointId: {CheckpointId}\n, Name: {Name}\n, CheckPointType: {Type}\n, Status: {Status}\n";
    }
}
