﻿using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

    public Checkpoint(int checkpointId, string name, CheckpointType type)
    {
        CheckpointId = checkpointId;
        Name = name;
        Type = type;
        Status = false;
        Tourists = new List<Tourist>();
    }
    public Checkpoint(string name, CheckpointType type)
    {
        Name = name;
        Type = type;
        Status = false;
        Tourists = new List<Tourist>();
    }
}