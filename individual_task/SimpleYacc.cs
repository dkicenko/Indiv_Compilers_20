// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, QUT 2005-2010
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.3.6
// Machine:  DESKTOP-MQGTEI6
// DateTime: 22.11.2021 8:51:18
// UserName: Jingle
// Input file <SimpleYacc.y>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using ProgramTree;

namespace SimpleParser
{
public enum Tokens {
    error=1,EOF=2,BEGIN=3,END=4,CYCLE=5,ASSIGN=6,
    SEMICOLON=7,DO=8,UNTIL=9,TO=10,LBRACKET=11,RBRACKET=12,
    COMMA=13,PLUS=14,MINUS=15,MULT=16,DIVISION=17,THEN=18,
    MOD=19,LSQBRACKET=20,RSQBRACKET=21,COLON=22,STRINGAP=23,INUM=24,
    RNUM=25,ID=26,WHILE=27,REPEAT=28,FOR=29,WRITE=30,
    VAR=31,IF=32,ELSE=33};

public struct ValueType
{ 
			public double dVal; 
			public int iVal; 
			public string sVal; 
			public Node nVal;
			public ExprNode eVal;
			public StatementNode stVal;
			public BlockNode blVal;
			public WhileNode whVal;
			public RepeatNode rVal;
			public ForNode fVal;
			public WriteNode wrVal;
			public VarDefNode vrVal;
			public IfNode ifelVal;
			public ArrayNode arVal;
			public SliceNode slVal;
       }
// Abstract base class for GPLEX scanners
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
  // Verbatim content from SimpleYacc.y
// Э�?и об�?явления добавля�?�?ся в класс GPPGParser, п�?едс�?авля�?�?ий собой па�?се�?, гене�?и�?�?ем�?й сис�?емой gppg
    public BlockNode root; // �?о�?невой �?зел син�?акси�?еского де�?ева 
    public Parser(AbstractScanner<ValueType, LexLocation> scanner) : base(scanner) { }
  // End verbatim content from SimpleYacc.y

#pragma warning disable 649
  private static Dictionary<int, string> aliasses;
#pragma warning restore 649
  private static Rule[] rules = new Rule[50];
  private static State[] states = new State[104];
  private static string[] nonTerms = new string[] {
      "expr", "ident", "assign", "statement", "cycle", "empty", "stlist", "block", 
      "var", "t", "f", "if", "array", "slice", "progr", "$accept", };

  static Parser() {
    states[0] = new State(new int[]{3,4},new int[]{-15,1,-8,3});
    states[1] = new State(new int[]{2,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{26,56,3,4,5,64,27,67,28,71,29,76,30,82,32,87,31,93,4,-15,7,-15},new int[]{-7,5,-4,75,-3,9,-2,10,-14,59,-8,62,-5,63,-12,86,-6,103});
    states[5] = new State(new int[]{4,6,7,7});
    states[6] = new State(-37);
    states[7] = new State(new int[]{26,56,3,4,5,64,27,67,28,71,29,76,30,82,32,87,31,93,4,-15,7,-15,9,-15},new int[]{-4,8,-3,9,-2,10,-14,59,-8,62,-5,63,-12,86,-6,103});
    states[8] = new State(-4);
    states[9] = new State(-5);
    states[10] = new State(new int[]{6,11});
    states[11] = new State(new int[]{26,18,24,44,11,45},new int[]{-1,12,-10,55,-11,54,-2,17,-13,42,-14,43});
    states[12] = new State(new int[]{14,13,15,48,4,-23,7,-23,9,-23,33,-23,10,-23});
    states[13] = new State(new int[]{26,18,24,44,11,45},new int[]{-10,14,-11,54,-2,17,-13,42,-14,43});
    states[14] = new State(new int[]{16,15,17,50,19,52,14,-26,15,-26,4,-26,7,-26,9,-26,33,-26,10,-26,12,-26,26,-26,3,-26,5,-26,27,-26,28,-26,29,-26,30,-26,32,-26,31,-26,8,-26,18,-26});
    states[15] = new State(new int[]{26,18,24,44,11,45},new int[]{-11,16,-2,17,-13,42,-14,43});
    states[16] = new State(-29);
    states[17] = new State(-32);
    states[18] = new State(new int[]{20,19,16,-22,17,-22,19,-22,14,-22,15,-22,4,-22,7,-22,9,-22,33,-22,10,-22,12,-22,26,-22,3,-22,5,-22,27,-22,28,-22,29,-22,30,-22,32,-22,31,-22,8,-22,18,-22});
    states[19] = new State(new int[]{24,20,22,34});
    states[20] = new State(new int[]{21,21,22,22});
    states[21] = new State(-39);
    states[22] = new State(new int[]{21,23,24,24,22,30});
    states[23] = new State(-40);
    states[24] = new State(new int[]{21,25,22,26});
    states[25] = new State(-42);
    states[26] = new State(new int[]{24,27,21,29});
    states[27] = new State(new int[]{21,28});
    states[28] = new State(-48);
    states[29] = new State(-49);
    states[30] = new State(new int[]{24,31,21,33});
    states[31] = new State(new int[]{21,32});
    states[32] = new State(-44);
    states[33] = new State(-47);
    states[34] = new State(new int[]{24,35,21,37,22,38});
    states[35] = new State(new int[]{21,36});
    states[36] = new State(-41);
    states[37] = new State(-43);
    states[38] = new State(new int[]{24,39,21,41});
    states[39] = new State(new int[]{21,40});
    states[40] = new State(-45);
    states[41] = new State(-46);
    states[42] = new State(-33);
    states[43] = new State(-34);
    states[44] = new State(-35);
    states[45] = new State(new int[]{26,18,24,44,11,45},new int[]{-1,46,-10,55,-11,54,-2,17,-13,42,-14,43});
    states[46] = new State(new int[]{12,47,14,13,15,48});
    states[47] = new State(-36);
    states[48] = new State(new int[]{26,18,24,44,11,45},new int[]{-10,49,-11,54,-2,17,-13,42,-14,43});
    states[49] = new State(new int[]{16,15,17,50,19,52,14,-27,15,-27,4,-27,7,-27,9,-27,33,-27,10,-27,12,-27,26,-27,3,-27,5,-27,27,-27,28,-27,29,-27,30,-27,32,-27,31,-27,8,-27,18,-27});
    states[50] = new State(new int[]{26,18,24,44,11,45},new int[]{-11,51,-2,17,-13,42,-14,43});
    states[51] = new State(-30);
    states[52] = new State(new int[]{26,18,24,44,11,45},new int[]{-11,53,-2,17,-13,42,-14,43});
    states[53] = new State(-31);
    states[54] = new State(-28);
    states[55] = new State(new int[]{16,15,17,50,19,52,14,-25,15,-25,4,-25,7,-25,9,-25,33,-25,10,-25,12,-25,26,-25,3,-25,5,-25,27,-25,28,-25,29,-25,30,-25,32,-25,31,-25,8,-25,18,-25});
    states[56] = new State(new int[]{20,57,6,-22});
    states[57] = new State(new int[]{24,58,22,34});
    states[58] = new State(new int[]{22,22});
    states[59] = new State(new int[]{6,60});
    states[60] = new State(new int[]{26,18,24,44,11,45},new int[]{-1,61,-10,55,-11,54,-2,17,-13,42,-14,43});
    states[61] = new State(new int[]{14,13,15,48,4,-24,7,-24,9,-24,33,-24,10,-24});
    states[62] = new State(-6);
    states[63] = new State(-7);
    states[64] = new State(new int[]{26,18,24,44,11,45},new int[]{-1,65,-10,55,-11,54,-2,17,-13,42,-14,43});
    states[65] = new State(new int[]{14,13,15,48,26,56,3,4,5,64,27,67,28,71,29,76,30,82,32,87,31,93,4,-15,7,-15,9,-15,33,-15},new int[]{-4,66,-3,9,-2,10,-14,59,-8,62,-5,63,-12,86,-6,103});
    states[66] = new State(-38);
    states[67] = new State(new int[]{26,18,24,44,11,45},new int[]{-1,68,-10,55,-11,54,-2,17,-13,42,-14,43});
    states[68] = new State(new int[]{8,69,14,13,15,48});
    states[69] = new State(new int[]{26,56,3,4,5,64,27,67,28,71,29,76,30,82,32,87,31,93,4,-15,7,-15,9,-15,33,-15},new int[]{-4,70,-3,9,-2,10,-14,59,-8,62,-5,63,-12,86,-6,103});
    states[70] = new State(-8);
    states[71] = new State(new int[]{26,56,3,4,5,64,27,67,28,71,29,76,30,82,32,87,31,93,9,-15,7,-15},new int[]{-7,72,-4,75,-3,9,-2,10,-14,59,-8,62,-5,63,-12,86,-6,103});
    states[72] = new State(new int[]{9,73,7,7});
    states[73] = new State(new int[]{26,18,24,44,11,45},new int[]{-1,74,-10,55,-11,54,-2,17,-13,42,-14,43});
    states[74] = new State(new int[]{14,13,15,48,4,-9,7,-9,9,-9,33,-9});
    states[75] = new State(-3);
    states[76] = new State(new int[]{26,56},new int[]{-3,77,-2,10,-14,59});
    states[77] = new State(new int[]{10,78});
    states[78] = new State(new int[]{26,18,24,44,11,45},new int[]{-1,79,-10,55,-11,54,-2,17,-13,42,-14,43});
    states[79] = new State(new int[]{8,80,14,13,15,48});
    states[80] = new State(new int[]{26,56,3,4,5,64,27,67,28,71,29,76,30,82,32,87,31,93,4,-15,7,-15,9,-15,33,-15},new int[]{-4,81,-3,9,-2,10,-14,59,-8,62,-5,63,-12,86,-6,103});
    states[81] = new State(-10);
    states[82] = new State(new int[]{11,83});
    states[83] = new State(new int[]{26,18,24,44,11,45},new int[]{-1,84,-10,55,-11,54,-2,17,-13,42,-14,43});
    states[84] = new State(new int[]{12,85,14,13,15,48});
    states[85] = new State(-11);
    states[86] = new State(-12);
    states[87] = new State(new int[]{26,18,24,44,11,45},new int[]{-1,88,-10,55,-11,54,-2,17,-13,42,-14,43});
    states[88] = new State(new int[]{18,89,14,13,15,48});
    states[89] = new State(new int[]{26,56,3,4,5,64,27,67,28,71,29,76,30,82,32,87,31,93,4,-15,7,-15,9,-15,33,-15},new int[]{-4,90,-3,9,-2,10,-14,59,-8,62,-5,63,-12,86,-6,103});
    states[90] = new State(new int[]{33,91,4,-17,7,-17,9,-17});
    states[91] = new State(new int[]{26,56,3,4,5,64,27,67,28,71,29,76,30,82,32,87,31,93,4,-15,7,-15,9,-15,33,-15},new int[]{-4,92,-3,9,-2,10,-14,59,-8,62,-5,63,-12,86,-6,103});
    states[92] = new State(-16);
    states[93] = new State(new int[]{26,98},new int[]{-9,94,-13,95});
    states[94] = new State(-13);
    states[95] = new State(new int[]{13,96,4,-18,7,-18,9,-18,33,-18});
    states[96] = new State(new int[]{26,98},new int[]{-9,97,-13,95});
    states[97] = new State(-20);
    states[98] = new State(new int[]{20,99,13,101,4,-19,7,-19,9,-19,33,-19});
    states[99] = new State(new int[]{24,100});
    states[100] = new State(new int[]{21,21});
    states[101] = new State(new int[]{26,98},new int[]{-9,102,-13,95});
    states[102] = new State(-21);
    states[103] = new State(-14);

    rules[1] = new Rule(-16, new int[]{-15,2});
    rules[2] = new Rule(-15, new int[]{-8});
    rules[3] = new Rule(-7, new int[]{-4});
    rules[4] = new Rule(-7, new int[]{-7,7,-4});
    rules[5] = new Rule(-4, new int[]{-3});
    rules[6] = new Rule(-4, new int[]{-8});
    rules[7] = new Rule(-4, new int[]{-5});
    rules[8] = new Rule(-4, new int[]{27,-1,8,-4});
    rules[9] = new Rule(-4, new int[]{28,-7,9,-1});
    rules[10] = new Rule(-4, new int[]{29,-3,10,-1,8,-4});
    rules[11] = new Rule(-4, new int[]{30,11,-1,12});
    rules[12] = new Rule(-4, new int[]{-12});
    rules[13] = new Rule(-4, new int[]{31,-9});
    rules[14] = new Rule(-4, new int[]{-6});
    rules[15] = new Rule(-6, new int[]{});
    rules[16] = new Rule(-12, new int[]{32,-1,18,-4,33,-4});
    rules[17] = new Rule(-12, new int[]{32,-1,18,-4});
    rules[18] = new Rule(-9, new int[]{-13});
    rules[19] = new Rule(-9, new int[]{26});
    rules[20] = new Rule(-9, new int[]{-13,13,-9});
    rules[21] = new Rule(-9, new int[]{26,13,-9});
    rules[22] = new Rule(-2, new int[]{26});
    rules[23] = new Rule(-3, new int[]{-2,6,-1});
    rules[24] = new Rule(-3, new int[]{-14,6,-1});
    rules[25] = new Rule(-1, new int[]{-10});
    rules[26] = new Rule(-1, new int[]{-1,14,-10});
    rules[27] = new Rule(-1, new int[]{-1,15,-10});
    rules[28] = new Rule(-10, new int[]{-11});
    rules[29] = new Rule(-10, new int[]{-10,16,-11});
    rules[30] = new Rule(-10, new int[]{-10,17,-11});
    rules[31] = new Rule(-10, new int[]{-10,19,-11});
    rules[32] = new Rule(-11, new int[]{-2});
    rules[33] = new Rule(-11, new int[]{-13});
    rules[34] = new Rule(-11, new int[]{-14});
    rules[35] = new Rule(-11, new int[]{24});
    rules[36] = new Rule(-11, new int[]{11,-1,12});
    rules[37] = new Rule(-8, new int[]{3,-7,4});
    rules[38] = new Rule(-5, new int[]{5,-1,-4});
    rules[39] = new Rule(-13, new int[]{26,20,24,21});
    rules[40] = new Rule(-14, new int[]{26,20,24,22,21});
    rules[41] = new Rule(-14, new int[]{26,20,22,24,21});
    rules[42] = new Rule(-14, new int[]{26,20,24,22,24,21});
    rules[43] = new Rule(-14, new int[]{26,20,22,21});
    rules[44] = new Rule(-14, new int[]{26,20,24,22,22,24,21});
    rules[45] = new Rule(-14, new int[]{26,20,22,22,24,21});
    rules[46] = new Rule(-14, new int[]{26,20,22,22,21});
    rules[47] = new Rule(-14, new int[]{26,20,24,22,22,21});
    rules[48] = new Rule(-14, new int[]{26,20,24,22,24,22,24,21});
    rules[49] = new Rule(-14, new int[]{26,20,24,22,24,22,21});
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
      case 2: // progr -> block
{ root = ValueStack[ValueStack.Depth-1].blVal; }
        break;
      case 3: // stlist -> statement
{ 
				CurrentSemanticValue.blVal = new BlockNode(ValueStack[ValueStack.Depth-1].stVal); 
			}
        break;
      case 4: // stlist -> stlist, SEMICOLON, statement
{ 
				ValueStack[ValueStack.Depth-3].blVal.Add(ValueStack[ValueStack.Depth-1].stVal); 
				CurrentSemanticValue.blVal = ValueStack[ValueStack.Depth-3].blVal; 
			}
        break;
      case 5: // statement -> assign
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 6: // statement -> block
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].blVal; }
        break;
      case 7: // statement -> cycle
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 8: // statement -> WHILE, expr, DO, statement
{
				CurrentSemanticValue.stVal = new WhileNode(ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].stVal);
			}
        break;
      case 9: // statement -> REPEAT, stlist, UNTIL, expr
{
				CurrentSemanticValue.stVal = new RepeatNode(ValueStack[ValueStack.Depth-1].eVal,ValueStack[ValueStack.Depth-3].blVal);
			}
        break;
      case 10: // statement -> FOR, assign, TO, expr, DO, statement
{
				CurrentSemanticValue.stVal = new ForNode(ValueStack[ValueStack.Depth-5].stVal,ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].stVal);
			}
        break;
      case 11: // statement -> WRITE, LBRACKET, expr, RBRACKET
{
			CurrentSemanticValue.stVal = new WriteNode(ValueStack[ValueStack.Depth-2].eVal);
		}
        break;
      case 12: // statement -> if
{
			CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].ifelVal;
		}
        break;
      case 13: // statement -> VAR, var
{
			CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].vrVal;
		}
        break;
      case 14: // statement -> empty
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 15: // empty -> /* empty */
{ CurrentSemanticValue.stVal = new EmptyNode(); }
        break;
      case 16: // if -> IF, expr, THEN, statement, ELSE, statement
{
		CurrentSemanticValue.ifelVal = new IfNode(ValueStack[ValueStack.Depth-5].eVal,ValueStack[ValueStack.Depth-3].stVal,ValueStack[ValueStack.Depth-1].stVal);
	}
        break;
      case 17: // if -> IF, expr, THEN, statement
{
		CurrentSemanticValue.ifelVal = new IfNode(ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].stVal,null);
	}
        break;
      case 18: // var -> array
{
			CurrentSemanticValue.vrVal = new VarDefNode(ValueStack[ValueStack.Depth-1].arVal);
		}
        break;
      case 19: // var -> ID
{
			CurrentSemanticValue.vrVal = new VarDefNode(ValueStack[ValueStack.Depth-1].sVal);
		}
        break;
      case 20: // var -> array, COMMA, var
{
			CurrentSemanticValue.vrVal.Add(ValueStack[ValueStack.Depth-3].arVal);
		}
        break;
      case 21: // var -> ID, COMMA, var
{
			CurrentSemanticValue.vrVal.Add(ValueStack[ValueStack.Depth-3].sVal);
		}
        break;
      case 22: // ident -> ID
{ CurrentSemanticValue.eVal = new IdNode(ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 23: // assign -> ident, ASSIGN, expr
{ CurrentSemanticValue.stVal = new AssignNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal); }
        break;
      case 24: // assign -> slice, ASSIGN, expr
{ CurrentSemanticValue.stVal = new AssignNode(ValueStack[ValueStack.Depth-3].slVal, ValueStack[ValueStack.Depth-1].eVal);}
        break;
      case 25: // expr -> t
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal; }
        break;
      case 26: // expr -> expr, PLUS, t
{ CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].eVal,'+'); }
        break;
      case 27: // expr -> expr, MINUS, t
{ CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].eVal,'-'); }
        break;
      case 28: // t -> f
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal; }
        break;
      case 29: // t -> t, MULT, f
{ CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].eVal,'*'); }
        break;
      case 30: // t -> t, DIVISION, f
{ CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].eVal,'/'); }
        break;
      case 31: // t -> t, MOD, f
{ CurrentSemanticValue.eVal = new BinaryNode(ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].eVal,'%'); }
        break;
      case 32: // f -> ident
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal as IdNode; }
        break;
      case 33: // f -> array
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].arVal as ArrayNode; }
        break;
      case 34: // f -> slice
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].slVal as SliceNode; }
        break;
      case 35: // f -> INUM
{ CurrentSemanticValue.eVal = new IntNumNode(ValueStack[ValueStack.Depth-1].iVal); }
        break;
      case 36: // f -> LBRACKET, expr, RBRACKET
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-2].eVal; }
        break;
      case 37: // block -> BEGIN, stlist, END
{ CurrentSemanticValue.blVal = ValueStack[ValueStack.Depth-2].blVal; }
        break;
      case 38: // cycle -> CYCLE, expr, statement
{ CurrentSemanticValue.stVal = new CycleNode(ValueStack[ValueStack.Depth-2].eVal, ValueStack[ValueStack.Depth-1].stVal); }
        break;
      case 39: // array -> ID, LSQBRACKET, INUM, RSQBRACKET
{ CurrentSemanticValue.arVal = new ArrayNode(ValueStack[ValueStack.Depth-4].sVal,ValueStack[ValueStack.Depth-2].iVal); }
        break;
      case 40: // slice -> ID, LSQBRACKET, INUM, COLON, RSQBRACKET
{ CurrentSemanticValue.slVal = new SliceNode(ValueStack[ValueStack.Depth-5].sVal,ValueStack[ValueStack.Depth-3].iVal,int.MaxValue); }
        break;
      case 41: // slice -> ID, LSQBRACKET, COLON, INUM, RSQBRACKET
{ CurrentSemanticValue.slVal = new SliceNode(ValueStack[ValueStack.Depth-5].sVal,0,ValueStack[ValueStack.Depth-2].iVal);}
        break;
      case 42: // slice -> ID, LSQBRACKET, INUM, COLON, INUM, RSQBRACKET
{CurrentSemanticValue.slVal = new SliceNode(ValueStack[ValueStack.Depth-6].sVal,ValueStack[ValueStack.Depth-4].iVal,ValueStack[ValueStack.Depth-2].iVal);}
        break;
      case 43: // slice -> ID, LSQBRACKET, COLON, RSQBRACKET
{CurrentSemanticValue.slVal = new SliceNode(ValueStack[ValueStack.Depth-4].sVal,0,int.MaxValue);}
        break;
      case 44: // slice -> ID, LSQBRACKET, INUM, COLON, COLON, INUM, RSQBRACKET
{CurrentSemanticValue.slVal = new SliceNode(ValueStack[ValueStack.Depth-7].sVal,ValueStack[ValueStack.Depth-5].iVal,int.MaxValue,ValueStack[ValueStack.Depth-2].iVal);}
        break;
      case 45: // slice -> ID, LSQBRACKET, COLON, COLON, INUM, RSQBRACKET
{CurrentSemanticValue.slVal = new SliceNode(ValueStack[ValueStack.Depth-6].sVal,0,int.MaxValue,ValueStack[ValueStack.Depth-2].iVal);}
        break;
      case 46: // slice -> ID, LSQBRACKET, COLON, COLON, RSQBRACKET
{CurrentSemanticValue.slVal = new SliceNode(ValueStack[ValueStack.Depth-5].sVal,0,int.MaxValue);}
        break;
      case 47: // slice -> ID, LSQBRACKET, INUM, COLON, COLON, RSQBRACKET
{CurrentSemanticValue.slVal = new SliceNode(ValueStack[ValueStack.Depth-6].sVal,ValueStack[ValueStack.Depth-4].iVal,int.MaxValue);}
        break;
      case 48: // slice -> ID, LSQBRACKET, INUM, COLON, INUM, COLON, INUM, RSQBRACKET
{CurrentSemanticValue.slVal = new SliceNode(ValueStack[ValueStack.Depth-8].sVal,ValueStack[ValueStack.Depth-6].iVal,ValueStack[ValueStack.Depth-4].iVal,ValueStack[ValueStack.Depth-2].iVal);}
        break;
      case 49: // slice -> ID, LSQBRACKET, INUM, COLON, INUM, COLON, RSQBRACKET
{CurrentSemanticValue.slVal = new SliceNode(ValueStack[ValueStack.Depth-7].sVal,ValueStack[ValueStack.Depth-5].iVal,ValueStack[ValueStack.Depth-3].iVal);}
        break;
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
