﻿/*
*   File:           Event.cs
*   Author:         Benjamin Albrecht
*   Date:           11/19/2017
*   Description:    Stores and modifies an Event from the database
*/


using System;
using System.Collections;
using Digital_Planner.Models;

namespace Digital_Planner.Sorting
{
    class PlannerEvent
    {
       // private static DigitalPlannerDbContext db = new DigitalPlannerDbContext();
        
        private Event dbEvent { get; set;}
        private float Score { get; set; }

        public float getScore()
        {
            return Score;
        }

        public Event getEvent()
        {
            return dbEvent;
        }

        public PlannerEvent(Event dbEvent)
        {
            //  Constructor

            this.dbEvent = dbEvent;

            GenerateScore();
        }

        private void GenerateScore()
        {
            //  Generates the event's score

            float daysUntilDue = (float)(CompleteBy - DateTime.Now).TotalDays;

            //score = 0;
            //score += (int)PriorityLevel * PlannerSettings.PRIORITY_WEIGHT;
            //score += Duration.Minutes * PlannerSettings.HOURS_WEIGHT / 60;
            //Just .Minutes gets the minutes component of the timespan.
            //score += (int)(Duration.TotalMinutes * PlannerSettings.HOURS_WEIGHT / 60.0);
            //score -= daysUntilDue * PlannerSettings.DUE_DATE_WEIGHT;

            Score = (int)(
                Score
                + (PriorityLevel * PlannerSettings.PRIORITY_WEIGHT)
                + (Duration.TotalHours * PlannerSettings.HOURS_WEIGHT * 60.0) //*60 converts hours to minutes
                - (daysUntilDue * PlannerSettings.DUE_DATE_WEIGHT)
                );
        }


        public String Title
        {
            get
            {
                return dbEvent.Title;
            }
            set
            {
                dbEvent.Title = value;
                GenerateScore();
            }
        }


        public int PriorityLevel
        {
            get
            {
                return dbEvent.Priority;
            }
            set
            {
                dbEvent.Priority = value;
                GenerateScore();
            }
        }


        public System.TimeSpan Duration
        {
            get
            {
                return dbEvent.Duration;
            }
            set
            {
                dbEvent.Duration = value;
                GenerateScore();
            }
        }


        public DateTime CompleteBy
        {
            get
            {
                return dbEvent.CompleteBy;
            }
            set
            {
                dbEvent.CompleteBy = value;
                GenerateScore();
            }
        }

        /*
        public float Score
        {
            get
            {
                return score;
            }
        }*/


        public DateTime OccursAt
        {
            get
            {
                return dbEvent.OccursAt;
            }
            set
            {
                dbEvent.OccursAt = value;
                GenerateScore();
            }
        }


        public bool AutoAssign
        {
            get
            {
                return dbEvent.AutoAssign;
            }
        }


        public void DebugPrint()
        {
            System.Diagnostics.Debug.WriteLine(Title + ":    hours: " + Duration + "   Score: " + Score + "   priority: " + PriorityLevel + "   Due Date: " + CompleteBy);
        }

    }
}