# Msil-Generator
Compiler of custom language which generates .NET Intermediate Language (MSIL).

##Grammar 

<programa> = main <declaracaorep> <modulorep> begin <corpo> end
<declaracaorep> = <declaracao> | <declaracao> <declaracaorep> | £
<modulorep> = <modulo> | <modulo> <modulorep> | £
<declaracao> = forward module <tipo> <identificador> ( <parametros formais> )
<tipo> = int | float | date | time | boolean | char | string
<parametros formais>  = <parametrosAux> | £ 
<parametrosAux> =  <parametro> | <parametro> ; <parametrosAux>
<parametro> = <tipo> : <lista de identificadores>
<lista de identificadores> = <identificador> | <identificador> , <lista de identificadores>
<modulo> =  module <identificador> ( <lista de parametros> ) begin <corpo> end
<lista de parametros> = <lista identificadores> | £ 
<corpo> = <declaracao de variaveis> <lista de comandos>
<declaracao de variaveis> = <variavel> | <variavel> <declaracao de variaveis> | £
<variavel> = <tipo> : <lista de identificadores> = <valor>
<valor> =   £ | <inteira> | <real> | <string> | <data> | <hora> |<caractere> | <string>
<lista de comandos> = <comando> ; | <comando> ; <ista de comandos>
<comando> = <atribuicao> | <entrada> | <saida> | <selecao> | <repeticao> | <retorno>
<atribuicao> = <identificador> <operador de atribuicao> <expressao> 
<operador de atribuicao> = = | += | -=
<entrada> = read ( <lista de identificadores> )
<saida> = write ( <lista de expressoes> )
<lista de expressoes> = <expressao> | <expressao> , <lista de expressoes>
<selecao> = ( <expressao> ) <ifs> end
<ifs> = ifTrue <listado>  | ifFalse <listado> | IfTrue <listado> IfFalse <listado>
<listado> = do <lista de comandos>
<repeticao> = ( <expressao> ) <while> do <lista de comandos> end
<while> =  whileTrue | whileFalse
<retorno> = ^ <expressao>

