using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Silver6wings.LabClassifier.Classifiers;

namespace Silver6wings.LabClassifier.Framework
{
    class Distributer
    {
        List<Strategy> _strategies;
        List<float> _weights;

        public Distributer(List<Strategy> strategys, List<float> weight)
        {
            if (strategys == null)
            {
                strategys = new List<Strategy>();
            }
            _strategies = strategys;

            if (weight == null)
            {
                weight = new List<float>();
            }
            _weights = weight;
        }

        public void add(Strategy strategy, float weight)
        {
            _strategies.Add(strategy);
            _weights.Add(weight);
        }

        public void remove(int i)
        {
            _strategies.RemoveAt(i);
            _weights.RemoveAt(i);
        }

        // 将item分发给各个strategy，并记录打分
        public Dictionary<string, float> distributeItem(string item)
        {
            Dictionary<string, float> result = new Dictionary<string, float>();
            if (item == null) return result;

            for (int i = 0; i < _strategies.Count; i++)
            {
                Strategy strategy = _strategies[i];
                string category = strategy.judgeItem(item);

                if (result.Keys.Contains(category))
                {
                    result[category] += _weights[i];
                }
                else
                {
                    result.Add(category, _weights[i]);
                }
            }

            return result;
        }

        public static void Output(Dictionary<string, float> result)
        {
            if (result == null) return;

            foreach (string key in result.Keys)
            {
                Console.WriteLine(result[key] + "\t" + key);
            }
        }
    }
}