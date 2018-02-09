# ArchitectureNetCore
Implementação inicial para projeto de arquitetura de referência em .NET CORE.

[Recursos]():

·        
Visual Studio 2017 Enterprise;

·        
LocalDB (instalado junto com o Visual Studio).

[Frameworks utilizados]():

·        
.Net Core 2.0 
para a camada de WEB;

·        
.Net Standard 2.0 para as demais camadas;

·        
Dapper.Contrib versão 1.50.0;

·        
Dapper.FluentMap.Dommel versõ 1.5.0

·        
Entity Framework Core SqlServer versão 2.0.1

[Estrutura]():

Projeto inicialmente criado com 5 camadas lógicas:

·        
ArchitectureNetCore.CrossCutting;

·        
ArchitectureNetCore.Data.Dapper

·        
ArchitectureNetCore.Data.EF

·        
ArchitectureNetCore.Domain

·        
ArchitectureNetCore.Web
