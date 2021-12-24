%{
// Эти объявления добавляются в класс GPPGParser, представляющий собой парсер, генерируемый системой gppg
    public Parser(AbstractScanner<int, LexLocation> scanner) : base(scanner) { }
%}

%output = SimpleYacc.cs

%namespace SimpleParser

%token BEGIN END CYCLE INUM RNUM ID ASSIGN SEMICOLON WHILE DO REPEAT UNTIL FOR TO LBRACKET RBRACKET WRITE
%token IF THEN ELSE VAR COMMA PLUS MINUS MULT DIVISION

%%

progr   : block
		;

stlist	: statement 
		| stlist SEMICOLON statement 
		;

statement: assign
		| block  
		| cycle  
		| WHILE expr DO statement
		| REPEAT stlist UNTIL expr
		| FOR assign TO expr DO statement
		| WRITE LBRACKET expr RBRACKET
		| if
		| VAR var
		;
expr : t
     | expr PLUS t
     | expr MINUS t
     ;

t    : f
     | t MULT f
     | t DIVISION f
     ;

f    : ident
     | INUM 
     | LBRACKET expr RBRACKET
     ;

if: IF expr THEN statement ELSE statement | IF expr THEN statement;
var: ID | ID COMMA var;

ident 	: ID 
		;
	
assign 	: ident ASSIGN expr 
		;

block	: BEGIN stlist END 
		;

cycle	: CYCLE expr statement 
		;
	
%%
