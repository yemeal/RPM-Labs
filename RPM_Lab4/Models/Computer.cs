using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace RPM_Lab4.Models
{
    public class Computer
    {
        public string CPU { get; set; }
        public int RAM { get; set; }
        public string GPU {  get; set; }
        public List<string> AdditionalComponents {  get; set; } = new List<string>();

        public Computer() { }

        public string Display()
        {
            string stringAdditionalComponents = AdditionalComponents.Count() > 0
                ? String.Join(", ", AdditionalComponents)
                : "None";


            return $"                 CPU:  {CPU}\n" +
                   $"                 RAM:  {RAM} GB\n" +
                   $"                 GPU:  {GPU}\n" +
                   $"AdditionalComponents:  {stringAdditionalComponents}\n";
        }


    }
}
