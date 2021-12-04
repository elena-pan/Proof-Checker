﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Jeorje
{
    class Program
    {
        static void Main(string[] args)
        {
            var jeorjeInput = "this is just a test\n" +
                              "#check ND\n" +
                              "!a\n" +
                              "|-\n" +
                              "z | !z\n" +
                              "\n" +
                              "0) !a premise\n" +
                              "1) !z | z by lem\n" +
                              "2) !a & (!z | z) by and_i on 0, 1\n" +
                              "3) !a & (!z | z) & (!a & (!z | z)) by and_i on 0,1,2 "
                ;
            
            string output;
            
            try
            {
                var tokens = Scanner.MaximalMunchScan(jeorjeInput);

                var proofFormat = Transformer.TransformTokens(tokens);

                switch (proofFormat.CheckType)
                {
                    case CheckType.ND:
                        var ndFormat = proofFormat as NDFormat;
                        List<AST> ndPremises = Parser.ParseLines(ndFormat.Premises);
                        AST ndGoal = Parser.ParseLine(ndFormat.Goal);
                        List<NDRule> ndProof = NDRulifier.RulifyLines(ndFormat.Proof);
                        
                        output = Validator.ValidateND(ndPremises, ndGoal, ndProof);
                        break;

                    default:
                        throw new Exception($"check type {proofFormat.CheckType.ToString()} not supported yet");
                }
            }
            
            catch (Exception e)
            {
                output = $"Exception thrown:\n{e.Message}";
            }
            
            Console.WriteLine(output);
            
        }
    }
}
