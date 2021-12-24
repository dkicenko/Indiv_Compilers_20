// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, QUT 2005-2010
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.3.6
// Machine:  DESKTOP-MQGTEI6
// DateTime: 17.09.2021 14:04:19
// UserName: Jingle
// Input file <SimpleYacc.y>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QUT.Gppg;

namespace SimpleParser
{
public enum Tokens {
    error=1,EOF=2,BEGIN=3,END=4,CYCLE=5,INUM=6,
    RNUM=7,ID=8,ASSIGN=9,SEMICOLON=10,WHILE=11,DO=12,
    REPEAT=13,UNTIL=14,FOR=15,TO=16,LBRACKET=17,RBRACKET=18,
    WRITE=19,IF=20,THEN=21,ELSE=22,VAR=23,COMMA=24,
    PLUS=25,MINUS=26,MULT=27,DIVISION=28};

// Abstract base class for GPLEX scanners
public abstract class ScanBase : AbstractScanner<int,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

public class Parser: ShiftReduceParser<int, LexLocation>
{
  // Verbatim content from SimpleYacc.y
// Ёти объ¤влени¤ добавл¤ютс¤ в класс GPPGParser, представл¤ющий собой парсер, генерируемый системой gppg
    public Parser(AbstractScanner<int, LexLocation> scanner) : base(scanner) { }
  // End verbatim content from SimpleYacc.y

#pragma warning disable 649
  private static Dictionary<int, string> aliasses;
#pragma warning restore 649
  private static Rule[] rules = new Rule[31];
  private static State[] states = new State[65];
  private static string[] nonTerms = new string[] {
      "progr", "$accept", "block", "stlist", "statement", "assign", "cycle", 
      "expr", "if", "var", "t", "f", "ident", };

  static Parser() {
    states[0] = new State(new int[]{3,4},new int[]{-1,1,-3,3});
    states[1] = new State(new int[]{2,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{8,18,3,4,5,31,11,34,13,38,15,43,19,49,20,54,23,60},new int[]{-4,5,-5,42,-6,9,-13,10,-3,29,-7,30,-9,53});
    states[5] = new State(new int[]{4,6,10,7});
    states[6] = new State(-29);
    states[7] = new State(new int[]{8,18,3,4,5,31,11,34,13,38,15,43,19,49,20,54,23,60},new int[]{-5,8,-6,9,-13,10,-3,29,-7,30,-9,53});
    states[8] = new State(-4);
    states[9] = new State(-5);
    states[10] = new State(new int[]{9,11});
    states[11] = new State(new int[]{8,18,6,19,17,20},new int[]{-8,12,-11,28,-12,27,-13,17});
    states[12] = new State(new int[]{25,13,26,23,4,-28,10,-28,14,-28,22,-28,16,-28});
    states[13] = new State(new int[]{8,18,6,19,17,20},new int[]{-11,14,-12,27,-13,17});
    states[14] = new State(new int[]{27,15,28,25,25,-15,26,-15,4,-15,10,-15,14,-15,22,-15,16,-15,18,-15,8,-15,3,-15,5,-15,11,-15,13,-15,15,-15,19,-15,20,-15,23,-15,12,-15,21,-15});
    states[15] = new State(new int[]{8,18,6,19,17,20},new int[]{-12,16,-13,17});
    states[16] = new State(-18);
    states[17] = new State(-20);
    states[18] = new State(-27);
    states[19] = new State(-21);
    states[20] = new State(new int[]{8,18,6,19,17,20},new int[]{-8,21,-11,28,-12,27,-13,17});
    states[21] = new State(new int[]{18,22,25,13,26,23});
    states[22] = new State(-22);
    states[23] = new State(new int[]{8,18,6,19,17,20},new int[]{-11,24,-12,27,-13,17});
    states[24] = new State(new int[]{27,15,28,25,25,-16,26,-16,4,-16,10,-16,14,-16,22,-16,16,-16,18,-16,8,-16,3,-16,5,-16,11,-16,13,-16,15,-16,19,-16,20,-16,23,-16,12,-16,21,-16});
    states[25] = new State(new int[]{8,18,6,19,17,20},new int[]{-12,26,-13,17});
    states[26] = new State(-19);
    states[27] = new State(-17);
    states[28] = new State(new int[]{27,15,28,25,25,-14,26,-14,4,-14,10,-14,14,-14,22,-14,16,-14,18,-14,8,-14,3,-14,5,-14,11,-14,13,-14,15,-14,19,-14,20,-14,23,-14,12,-14,21,-14});
    states[29] = new State(-6);
    states[30] = new State(-7);
    states[31] = new State(new int[]{8,18,6,19,17,20},new int[]{-8,32,-11,28,-12,27,-13,17});
    states[32] = new State(new int[]{25,13,26,23,8,18,3,4,5,31,11,34,13,38,15,43,19,49,20,54,23,60},new int[]{-5,33,-6,9,-13,10,-3,29,-7,30,-9,53});
    states[33] = new State(-30);
    states[34] = new State(new int[]{8,18,6,19,17,20},new int[]{-8,35,-11,28,-12,27,-13,17});
    states[35] = new State(new int[]{12,36,25,13,26,23});
    states[36] = new State(new int[]{8,18,3,4,5,31,11,34,13,38,15,43,19,49,20,54,23,60},new int[]{-5,37,-6,9,-13,10,-3,29,-7,30,-9,53});
    states[37] = new State(-8);
    states[38] = new State(new int[]{8,18,3,4,5,31,11,34,13,38,15,43,19,49,20,54,23,60},new int[]{-4,39,-5,42,-6,9,-13,10,-3,29,-7,30,-9,53});
    states[39] = new State(new int[]{14,40,10,7});
    states[40] = new State(new int[]{8,18,6,19,17,20},new int[]{-8,41,-11,28,-12,27,-13,17});
    states[41] = new State(new int[]{25,13,26,23,4,-9,10,-9,14,-9,22,-9});
    states[42] = new State(-3);
    states[43] = new State(new int[]{8,18},new int[]{-6,44,-13,10});
    states[44] = new State(new int[]{16,45});
    states[45] = new State(new int[]{8,18,6,19,17,20},new int[]{-8,46,-11,28,-12,27,-13,17});
    states[46] = new State(new int[]{12,47,25,13,26,23});
    states[47] = new State(new int[]{8,18,3,4,5,31,11,34,13,38,15,43,19,49,20,54,23,60},new int[]{-5,48,-6,9,-13,10,-3,29,-7,30,-9,53});
    states[48] = new State(-10);
    states[49] = new State(new int[]{17,50});
    states[50] = new State(new int[]{8,18,6,19,17,20},new int[]{-8,51,-11,28,-12,27,-13,17});
    states[51] = new State(new int[]{18,52,25,13,26,23});
    states[52] = new State(-11);
    states[53] = new State(-12);
    states[54] = new State(new int[]{8,18,6,19,17,20},new int[]{-8,55,-11,28,-12,27,-13,17});
    states[55] = new State(new int[]{21,56,25,13,26,23});
    states[56] = new State(new int[]{8,18,3,4,5,31,11,34,13,38,15,43,19,49,20,54,23,60},new int[]{-5,57,-6,9,-13,10,-3,29,-7,30,-9,53});
    states[57] = new State(new int[]{22,58,4,-24,10,-24,14,-24});
    states[58] = new State(new int[]{8,18,3,4,5,31,11,34,13,38,15,43,19,49,20,54,23,60},new int[]{-5,59,-6,9,-13,10,-3,29,-7,30,-9,53});
    states[59] = new State(-23);
    states[60] = new State(new int[]{8,62},new int[]{-10,61});
    states[61] = new State(-13);
    states[62] = new State(new int[]{24,63,4,-25,10,-25,14,-25,22,-25});
    states[63] = new State(new int[]{8,62},new int[]{-10,64});
    states[64] = new State(-26);

    rules[1] = new Rule(-2, new int[]{-1,2});
    rules[2] = new Rule(-1, new int[]{-3});
    rules[3] = new Rule(-4, new int[]{-5});
    rules[4] = new Rule(-4, new int[]{-4,10,-5});
    rules[5] = new Rule(-5, new int[]{-6});
    rules[6] = new Rule(-5, new int[]{-3});
    rules[7] = new Rule(-5, new int[]{-7});
    rules[8] = new Rule(-5, new int[]{11,-8,12,-5});
    rules[9] = new Rule(-5, new int[]{13,-4,14,-8});
    rules[10] = new Rule(-5, new int[]{15,-6,16,-8,12,-5});
    rules[11] = new Rule(-5, new int[]{19,17,-8,18});
    rules[12] = new Rule(-5, new int[]{-9});
    rules[13] = new Rule(-5, new int[]{23,-10});
    rules[14] = new Rule(-8, new int[]{-11});
    rules[15] = new Rule(-8, new int[]{-8,25,-11});
    rules[16] = new Rule(-8, new int[]{-8,26,-11});
    rules[17] = new Rule(-11, new int[]{-12});
    rules[18] = new Rule(-11, new int[]{-11,27,-12});
    rules[19] = new Rule(-11, new int[]{-11,28,-12});
    rules[20] = new Rule(-12, new int[]{-13});
    rules[21] = new Rule(-12, new int[]{6});
    rules[22] = new Rule(-12, new int[]{17,-8,18});
    rules[23] = new Rule(-9, new int[]{20,-8,21,-5,22,-5});
    rules[24] = new Rule(-9, new int[]{20,-8,21,-5});
    rules[25] = new Rule(-10, new int[]{8});
    rules[26] = new Rule(-10, new int[]{8,24,-10});
    rules[27] = new Rule(-13, new int[]{8});
    rules[28] = new Rule(-6, new int[]{-13,9,-8});
    rules[29] = new Rule(-3, new int[]{3,-4,4});
    rules[30] = new Rule(-7, new int[]{5,-8,-5});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
    switch (action)
    {
    }
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliasses != null && aliasses.ContainsKey(terminal))
        return aliasses[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

}
}
