using System;
using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class WalkerDetailModel
    {
        public Walker Walker { get; set; }
        public List<Walks> Walks { get; set; }
    }
}