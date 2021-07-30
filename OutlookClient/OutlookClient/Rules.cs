using OutlookClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    public class Rules
    {
        public Dictionary<Rule, Func<List<string>, string>> rulesList = new Dictionary<Rule, Func<List<string>, string>>();
        public Rules()
        {
            rulesList.Add(Rule.RedirectToFolder, RedirectToFolder);
            rulesList.Add(Rule.ResendMail, ResendMail);
            rulesList.Add(Rule.RemoveMail, RemoveMail);
        }

        public enum Rule
        {
            RedirectToFolder,
            ResendMail,
            RemoveMail
        }

        
        private string RedirectToFolder(List<string> param)
        {
            return "";
        }
        private string ResendMail(List<string> param)
        {
            return "";
        }
        private string RemoveMail(List<string> param)
        {
            return "";
        }
        public string ApllyRule(Rule rule, List<string> param)
        {
            return rulesList[rule](param);
        }
    }
}
