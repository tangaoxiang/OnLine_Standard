 delete from dbo.a_single_project;
delete from dbo.b_single_project;
delete from dbo.c_single_project;
delete from dbo.construction_project_a;
delete from dbo.construction_project_b;
delete from dbo.construction_project_c;
delete from dbo.T_Construction_Project;
delete from dbo.T_Archive;
delete from dbo.T_Company where CompanyID not in(2);
								   
								   
delete from dbo.T_EFile;
delete from dbo.T_FileAttach;
delete from dbo.T_FileList;
delete from dbo.T_MyArchive;
delete from dbo.T_SingleProject;
delete from dbo.T_SingleProjectCompany;
delete from dbo.T_SingleProjectUser;
delete from dbo.T_WorkFlowDefine;
delete from dbo.T_SingleProject_PIC;
delete from dbo.T_WorkFlowDoResult;


delete from dbo.T_OperationLog;
delete from dbo.T_Question;
delete from dbo.T_QuestionAnswer;
delete from dbo.T_ReadyCheckBook;
delete from dbo.T_Train_Plan;
delete from dbo.T_Train_Rec;
delete from dbo.T_RoleRight where RoleID in(
select RoleID from dbo.T_Role where CompanyID not in(2));
delete from dbo.T_UsersInfo where CompanyID not in(2);
delete from dbo.T_Role where CompanyID not in(2);


 

