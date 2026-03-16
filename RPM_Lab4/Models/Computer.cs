using RPM_Lab4.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace RPM_Lab4.Models
{
    public class Computer : ICopiable<Computer>
    {
        public string CPU { get; set; }
        public int RAM { get; set; }
        public string GPU {  get; set; }
        public List<string> AdditionalComponents {  get; set; } = new List<string>();

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

        public Computer ShallowCopy()
        {
            return (Computer) this.MemberwiseClone();
        }
        public Computer DeepCopy()
        {
            Computer clone = (Computer) MemberwiseClone();
            clone.AdditionalComponents = new List<string>(AdditionalComponents);
            return clone;
        }
    }
}
