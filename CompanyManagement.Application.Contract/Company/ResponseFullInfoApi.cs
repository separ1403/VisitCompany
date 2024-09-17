using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Company
{
 
        public class ResponseFullInfoApi
        {
            public int took { get; set; }
            public bool timed_out { get; set; }
            public _Shards _shards { get; set; }
            public Hits hits { get; set; }

        }

        public class _Shards
        {
            public int total { get; set; }
            public int successful { get; set; }
            public int skipped { get; set; }
            public int failed { get; set; }
        }

        public class Hits
        {
            public Total total { get; set; }
            public float? max_score { get; set; }
            public Hit[] hits { get; set; }
        }

        public class Total
        {
            public int value { get; set; }
            public string relation { get; set; }
        }

        public class Hit
        {
            public string _index { get; set; }
            public string _id { get; set; }
            public float _score { get; set; }
            public string[] _ignored { get; set; }
            public _Source _source { get; set; }
        }

        public class _Source
        {
            public long entityId { get; set; }
            public string id { get; set; }
            public string titleFa { get; set; }
            public string titleEn { get; set; }
            public string pictureUrl { get; set; }
            public DateTime date { get; set; }
            public string owner { get; set; }
            public string ownerLink { get; set; }
            public int views { get; set; }
            public int companyCount { get; set; }
            public string link { get; set; }
            public int favoriteListEntityCount { get; set; }
            public int entityType { get; set; }
            public string subtitle { get; set; }
            public string tagline { get; set; }
            public string placeOfIssue { get; set; }
        }
    }

