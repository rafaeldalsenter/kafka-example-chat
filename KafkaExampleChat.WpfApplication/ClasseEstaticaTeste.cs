using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaExampleChat.WpfApplication
{
    public static class ClasseEstaticaTeste
    {
        public static string GetClientId => Guid.NewGuid().ToString();
    }
}