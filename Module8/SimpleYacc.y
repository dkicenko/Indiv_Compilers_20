%{
// Эти объявления добавляются в класс GPPGParser, представляющий собой парсер, генерируемый системой gppg
    public BlockNode root; // Корневой узел синтаксического дерева 
    public Parser(AbstractScanner<ValueType, LexLocation> scanner) : base(scanner) { }
	private bool InDefSect = false;
%}

%output = SimpleYacc.cs

%union { 
			public double dVal; 
			public int iVal; 
			public string sVal; 
			public Node nVal;
			public ExprNode eVal;
			public StatementNode stVal;
			public BlockNode blVal;
			public IfNode ifelVal;
			public WhileNode whVal;
			public RepeatNode rVal;
       }

%using System.IO;
%using ProgramTree;

%namespace SimpleParser

%start progr

%token BEGIN END CYCLE ASSIGN ASSIGNPLUS ASSIGNMINUS ASSIGNMULT SEMICOLON WRITE VAR PLUS MINUS MULT DIV MOD LPAREN RPAREN COLUMN THEN DO UNTIL
%token <iVal> INUM 
%token <dVal> RNUM 
%token <sVal> ID
%token <ifelVal> IF ELSE
%token <whVal> WHILE
%token <rVal> REPEAT

%type <eVal> expr ident T F 
%type <stVal> statement assign block cycle write empty var varlist 
%type <blVal> stlist block
%type <ifelVal> if

%%

progr   : block { root = $1; }
		;

stlist	: statement 
			{ 
				$$ = new BlockNode($1); 
			}
		| stlist SEMICOLON statement 
			{ 
				$1.Add($3); 
				$$ = $1; 
			}	
		;

statement: assign { $$ = $1; }
		| block   { $$ = $1; }
		| cycle   { $$ = $1; }
		| write   { $$ = $1; }
		| var     { $$ = $1; }
		| empty   { $$ = $1; }
		| if      { $$ = $1; }
		| WHILE expr DO statement
			{
				$$ = new WhileNode($2,$4);
			}
		| REPEAT stlist UNTIL expr
			{
				$$ = new RepeatNode($4,$2);
			}
		;

empty	: { $$ = new EmptyNode(); }
		;
	
ident 	: ID 
		{
			if (!InDefSect)
				if (!SymbolTable.vars.ContainsKey($1))
					throw new Exception("("+@1.StartLine+","+@1.StartColumn+"): Переменная "+$1+" не описана");
			$$ = new IdNode($1); 
		}	
	;
	
assign 	: ident ASSIGN expr { $$ = new AssignNode($1 as IdNode, $3); }
		;

expr	: expr PLUS T { $$ = new BinOpNode($1,$3,'+'); }
		| expr MINUS T { $$ = new BinOpNode($1,$3,'-'); }
		| T { $$ = $1; }
		;
		
T 		: T MULT F { $$ = new BinOpNode($1,$3,'*'); }
		| T DIV F { $$ = new BinOpNode($1,$3,'/'); }
		| T MOD F { $$ = new BinOpNode($1,$3,'%'); }
		| F { $$ = $1; }
		;
		
F 		: ident  { $$ = $1 as IdNode; }
		| INUM { $$ = new IntNumNode($1); }
		| LPAREN expr RPAREN { $$ = $2; }
		;

block	: BEGIN stlist END { $$ = $2; }
		;

cycle	: CYCLE expr statement { $$ = new CycleNode($2,$3); }
		;
		
write	: WRITE LPAREN expr RPAREN { $$ = new WriteNode($3); }
		;
		
var		: VAR { InDefSect = true; } varlist 
		{ 
			foreach (var v in ($3 as VarDefNode).vars)
				SymbolTable.NewVarDef(v.Name, type.tint);
			InDefSect = false;	
		}
		;

varlist	: ident 
		{ 
			$$ = new VarDefNode($1 as IdNode); 
		}
		| varlist COLUMN ident 
		{ 
			($1 as VarDefNode).Add($3 as IdNode);
			$$ = $1;
		}
		;
		
if: IF expr THEN statement ELSE statement 
	{
		$$ = new IfNode($2,$4,$6);
	}
	| IF expr THEN statement
	{
		$$ = new IfNode($2,$4);
	}
	;

	
%%

