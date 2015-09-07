using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Rules;

namespace Fortis.Helpers
{
    public static class RulesHelper
    {
        public static bool EvaluateRule(Field field)
        {
            var ruleContext = new RuleContext();

            foreach (Rule<RuleContext> rule in RuleFactory.GetRules<RuleContext>(field).Rules)
            {
                if (!EvaluateSingleRule(rule, ruleContext))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool EvaluateSingleRule(Rule<RuleContext> rule, RuleContext ruleContext)
        {
            if (rule.Condition == null)
                return true;

            var stack = new RuleStack();
            rule.Condition.Evaluate(ruleContext, stack);

            if (ruleContext.IsAborted)
            {
                return false;
            }
            return (stack.Count != 0) && ((bool)stack.Pop());
        }
    }
}
