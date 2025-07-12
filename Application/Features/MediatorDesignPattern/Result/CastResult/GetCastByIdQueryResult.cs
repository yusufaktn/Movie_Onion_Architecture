﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Result.CastResult
{
    public class GetCastByIdQueryResult
    {
        public int CastId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }

        public string Biography { get; set; }
        public string? Overview { get; set; }
    }
}
