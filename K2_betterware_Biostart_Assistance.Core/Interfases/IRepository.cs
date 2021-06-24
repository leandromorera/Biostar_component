using K2_betterware_Biostart_Assistance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace K2_betterware_Biostart_Assistance.Core.Interfases
{
    public interface IRepository
    {
        

        string Token_bio();
        string User_bio();
        string Event_search_bio();
        string Device_bio();
        string[] bio_event_search(string tk_bio, string jsonb);
        

    }

}