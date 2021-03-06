USE [alatong]
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Admin_IsLock]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Admin]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Admin_IsLock]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Admin] DROP CONSTRAINT [DF_T_Admin_IsLock]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Admin_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Admin]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Admin_UserRole]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Admin] DROP CONSTRAINT [DF_T_Admin_UserRole]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_AdminMenu_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_AdminMenu]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_AdminMenu_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_AdminMenu] DROP CONSTRAINT [DF_T_AdminMenu_IsShow]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_AdminMenu_PID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_AdminMenu]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_AdminMenu_PID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_AdminMenu] DROP CONSTRAINT [DF_T_AdminMenu_PID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_AdminMenu_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_AdminMenu]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_AdminMenu_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_AdminMenu] DROP CONSTRAINT [DF_T_AdminMenu_SID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Book_UserID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Book]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Book_UserID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Book] DROP CONSTRAINT [DF_T_Book_UserID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Book_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Book]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Book_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Book] DROP CONSTRAINT [DF_T_Book_NoteTime]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Book_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Book]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Book_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Book] DROP CONSTRAINT [DF_T_Book_IsShow]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Book_IsRecommend]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Book]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Book_IsRecommend]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Book] DROP CONSTRAINT [DF_T_Book_IsRecommend]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Book_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Book]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Book_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Book] DROP CONSTRAINT [DF_T_Book_SID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Info_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Info]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Info_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Info] DROP CONSTRAINT [DF_T_Info_SID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_JM_TypeID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_JM]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_JM_TypeID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_JM] DROP CONSTRAINT [DF_T_JM_TypeID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_JM_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_JM]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_JM_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_JM] DROP CONSTRAINT [DF_T_JM_NoteTime]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Link_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Link]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Link_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Link] DROP CONSTRAINT [DF_T_Link_SID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Link_TypeID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Link]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Link_TypeID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Link] DROP CONSTRAINT [DF_T_Link_TypeID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Link_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Link]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Link_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Link] DROP CONSTRAINT [DF_T_Link_IsShow]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Link_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Link]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Link_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Link] DROP CONSTRAINT [DF_T_Link_NoteTime]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Link_IsShowOther]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Link]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Link_IsShowOther]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Link] DROP CONSTRAINT [DF_T_Link_IsShowOther]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_LinkType_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_LinkType]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_LinkType_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_LinkType] DROP CONSTRAINT [DF_T_LinkType_SID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] DROP CONSTRAINT [DF_T_News_NoteTime]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] DROP CONSTRAINT [DF_T_News_IsShow]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] DROP CONSTRAINT [DF_T_News_SID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_NewType]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_NewType]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] DROP CONSTRAINT [DF_T_News_NewType]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_Hits]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_Hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] DROP CONSTRAINT [DF_T_News_Hits]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_IsRecommend]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_IsRecommend]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] DROP CONSTRAINT [DF_T_News_IsRecommend]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_NewType_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_NewType]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_NewType_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_NewType] DROP CONSTRAINT [DF_T_NewType_SID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_NewType_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_NewType]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_NewType_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_NewType] DROP CONSTRAINT [DF_T_NewType_IsShow]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_NewType_PID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_NewType]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_NewType_PID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_NewType] DROP CONSTRAINT [DF_T_NewType_PID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_ProID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_ProID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] DROP CONSTRAINT [DF_T_OrderForm_ProID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] DROP CONSTRAINT [DF_T_OrderForm_NoteTime]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_Price]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_Price]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] DROP CONSTRAINT [DF_T_OrderForm_Price]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_UserID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_UserID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] DROP CONSTRAINT [DF_T_OrderForm_UserID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_IsBilling]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_IsBilling]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] DROP CONSTRAINT [DF_T_OrderForm_IsBilling]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_Status]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_Status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] DROP CONSTRAINT [DF_T_OrderForm_Status]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_IsPay]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_IsPay]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] DROP CONSTRAINT [DF_T_OrderForm_IsPay]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_PayPrice]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_PayPrice]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] DROP CONSTRAINT [DF_T_OrderForm_PayPrice]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderFormStatus_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderFormStatus]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderFormStatus_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderFormStatus] DROP CONSTRAINT [DF_T_OrderFormStatus_IsShow]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderFormStatus_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderFormStatus]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderFormStatus_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderFormStatus] DROP CONSTRAINT [DF_T_OrderFormStatus_SID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] DROP CONSTRAINT [DF_T_Products_NoteTime]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] DROP CONSTRAINT [DF_T_Products_IsShow]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_IsNew]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_IsNew]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] DROP CONSTRAINT [DF_T_Products_IsNew]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_IsRecommend]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_IsRecommend]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] DROP CONSTRAINT [DF_T_Products_IsRecommend]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] DROP CONSTRAINT [DF_T_Products_SID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_TypeID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_TypeID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] DROP CONSTRAINT [DF_T_Products_TypeID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_Hits]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_Hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] DROP CONSTRAINT [DF_T_Products_Hits]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_SaleNum]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_SaleNum]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] DROP CONSTRAINT [DF_T_Products_SaleNum]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_ProType_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_ProType]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_ProType_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_ProType] DROP CONSTRAINT [DF_T_ProType_SID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_ProType_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_ProType]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_ProType_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_ProType] DROP CONSTRAINT [DF_T_ProType_IsShow]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_ProType_PID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_ProType]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_ProType_PID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_ProType] DROP CONSTRAINT [DF_T_ProType_PID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_UserType]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_UserType]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] DROP CONSTRAINT [DF_T_User_UserType]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] DROP CONSTRAINT [DF_T_User_NoteTime]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_LoginTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_LoginTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] DROP CONSTRAINT [DF_T_User_LoginTime]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_AreaID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_AreaID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] DROP CONSTRAINT [DF_T_User_AreaID]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_AreaID1]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_AreaID1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] DROP CONSTRAINT [DF_T_User_AreaID1]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_IsLock]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_IsLock]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] DROP CONSTRAINT [DF_T_User_IsLock]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_Sex]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_Sex]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] DROP CONSTRAINT [DF_T_User_Sex]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] DROP CONSTRAINT [DF_T_User_SID]
END


End
GO
/****** Object:  View [dbo].[V_Link]    Script Date: 02/10/2015 12:03:49 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_Link]'))
DROP VIEW [dbo].[V_Link]
GO
/****** Object:  View [dbo].[V_News]    Script Date: 02/10/2015 12:03:49 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_News]'))
DROP VIEW [dbo].[V_News]
GO
/****** Object:  View [dbo].[V_OrderForm]    Script Date: 02/10/2015 12:03:49 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_OrderForm]'))
DROP VIEW [dbo].[V_OrderForm]
GO
/****** Object:  View [dbo].[V_Products]    Script Date: 02/10/2015 12:03:49 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_Products]'))
DROP VIEW [dbo].[V_Products]
GO
/****** Object:  StoredProcedure [dbo].[PageByRowNumber]    Script Date: 02/10/2015 12:03:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PageByRowNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PageByRowNumber]
GO
/****** Object:  Table [dbo].[T_Admin]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Admin]') AND type in (N'U'))
DROP TABLE [dbo].[T_Admin]
GO
/****** Object:  Table [dbo].[T_AdminMenu]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_AdminMenu]') AND type in (N'U'))
DROP TABLE [dbo].[T_AdminMenu]
GO
/****** Object:  Table [dbo].[T_Book]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Book]') AND type in (N'U'))
DROP TABLE [dbo].[T_Book]
GO
/****** Object:  Table [dbo].[T_Info]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Info]') AND type in (N'U'))
DROP TABLE [dbo].[T_Info]
GO
/****** Object:  Table [dbo].[T_JM]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_JM]') AND type in (N'U'))
DROP TABLE [dbo].[T_JM]
GO
/****** Object:  Table [dbo].[T_Link]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Link]') AND type in (N'U'))
DROP TABLE [dbo].[T_Link]
GO
/****** Object:  Table [dbo].[T_LinkType]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_LinkType]') AND type in (N'U'))
DROP TABLE [dbo].[T_LinkType]
GO
/****** Object:  Table [dbo].[T_News]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_News]') AND type in (N'U'))
DROP TABLE [dbo].[T_News]
GO
/****** Object:  Table [dbo].[T_NewType]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_NewType]') AND type in (N'U'))
DROP TABLE [dbo].[T_NewType]
GO
/****** Object:  Table [dbo].[T_OrderForm]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_OrderForm]') AND type in (N'U'))
DROP TABLE [dbo].[T_OrderForm]
GO
/****** Object:  Table [dbo].[T_OrderFormStatus]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_OrderFormStatus]') AND type in (N'U'))
DROP TABLE [dbo].[T_OrderFormStatus]
GO
/****** Object:  Table [dbo].[T_Products]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Products]') AND type in (N'U'))
DROP TABLE [dbo].[T_Products]
GO
/****** Object:  Table [dbo].[T_ProType]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_ProType]') AND type in (N'U'))
DROP TABLE [dbo].[T_ProType]
GO
/****** Object:  Table [dbo].[T_SEO]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_SEO]') AND type in (N'U'))
DROP TABLE [dbo].[T_SEO]
GO
/****** Object:  Table [dbo].[T_User]    Script Date: 02/10/2015 12:03:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_User]') AND type in (N'U'))
DROP TABLE [dbo].[T_User]
GO
/****** Object:  Table [dbo].[T_User]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[PassWord] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[UserType] [int] NULL,
	[ClientName] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[NoteTime] [datetime] NULL,
	[LoginTime] [datetime] NULL,
	[AreaID] [int] NULL,
	[AreaID1] [int] NULL,
	[Linkman] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Tel] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[Mobile] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[Address] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[Mail] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[Intro] [ntext] COLLATE Chinese_PRC_CI_AS NULL,
	[Pic] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Map] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[IsLock] [int] NULL,
	[BusinessLicensePic] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrganizationLicensePic] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[AuthorizePic] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Sex] [int] NULL,
	[Birthday] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SID] [int] NULL,
 CONSTRAINT [PK_T_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'UserName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UserName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'PassWord'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'PassWord'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'UserType'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型；1表示普通用户，2表示商家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UserType'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'ClientName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户称呼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'ClientName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'NoteTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'NoteTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'AreaID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区域，省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'AreaID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'AreaID1'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区域，市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'AreaID1'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Linkman'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Linkman'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Tel'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Tel'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Mobile'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Address'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Address'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Mail'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Mail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Intro'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司介绍' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Intro'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Pic'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'形象图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Pic'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Map'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地图标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Map'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'IsLock'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否锁定' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'IsLock'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'BusinessLicensePic'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'营业执照' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'BusinessLicensePic'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'OrganizationLicensePic'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织机构代码证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'OrganizationLicensePic'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'AuthorizePic'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'授权证明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'AuthorizePic'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Sex'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别，1男，2女' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Sex'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Birthday'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Birthday'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'SID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'SID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User'
GO
/****** Object:  Table [dbo].[T_SEO]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_SEO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_SEO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Keywords] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Description] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Author] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[PageName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[PageNameCalled] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_T_SEO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_SEO', N'COLUMN',N'Title'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SEO', @level2type=N'COLUMN',@level2name=N'Title'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_SEO', N'COLUMN',N'Keywords'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键词' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SEO', @level2type=N'COLUMN',@level2name=N'Keywords'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_SEO', N'COLUMN',N'Description'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SEO', @level2type=N'COLUMN',@level2name=N'Description'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_SEO', N'COLUMN',N'Author'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SEO', @level2type=N'COLUMN',@level2name=N'Author'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_SEO', N'COLUMN',N'PageName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SEO', @level2type=N'COLUMN',@level2name=N'PageName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_SEO', N'COLUMN',N'PageNameCalled'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面中文名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SEO', @level2type=N'COLUMN',@level2name=N'PageNameCalled'
GO
SET IDENTITY_INSERT [dbo].[T_SEO] ON
INSERT [dbo].[T_SEO] ([ID], [Title], [Keywords], [Description], [Author], [PageName], [PageNameCalled]) VALUES (1, N'阿拉桐-特色米粉加盟领导品牌', NULL, NULL, NULL, N'index.aspx', NULL)
INSERT [dbo].[T_SEO] ([ID], [Title], [Keywords], [Description], [Author], [PageName], [PageNameCalled]) VALUES (2, N'阿拉桐-特色米粉加盟领导品牌', NULL, NULL, NULL, N'about.aspx', NULL)
INSERT [dbo].[T_SEO] ([ID], [Title], [Keywords], [Description], [Author], [PageName], [PageNameCalled]) VALUES (3, N'阿拉桐-特色米粉加盟领导品牌', NULL, NULL, NULL, N'jm.aspx', NULL)
INSERT [dbo].[T_SEO] ([ID], [Title], [Keywords], [Description], [Author], [PageName], [PageNameCalled]) VALUES (4, N'阿拉桐-特色米粉加盟领导品牌', NULL, NULL, NULL, N'news.aspx', NULL)
INSERT [dbo].[T_SEO] ([ID], [Title], [Keywords], [Description], [Author], [PageName], [PageNameCalled]) VALUES (5, N'阿拉桐-特色米粉加盟领导品牌', NULL, NULL, NULL, N'products.aspx', NULL)
INSERT [dbo].[T_SEO] ([ID], [Title], [Keywords], [Description], [Author], [PageName], [PageNameCalled]) VALUES (6, N'阿拉桐-特色米粉加盟领导品牌', NULL, NULL, NULL, N'jm_book.aspx', NULL)
SET IDENTITY_INSERT [dbo].[T_SEO] OFF
/****** Object:  Table [dbo].[T_ProType]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_ProType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_ProType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeCalled] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SID] [int] NULL,
	[IsShow] [int] NULL,
	[Memo] [ntext] COLLATE Chinese_PRC_CI_AS NULL,
	[PID] [int] NULL,
	[Pic] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Pic1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Tip] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_T_ProType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[T_ProType] ON
INSERT [dbo].[T_ProType] ([ID], [TypeCalled], [SID], [IsShow], [Memo], [PID], [Pic], [Pic1], [Tip]) VALUES (1, N'米线', 10000, 1, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[T_ProType] ([ID], [TypeCalled], [SID], [IsShow], [Memo], [PID], [Pic], [Pic1], [Tip]) VALUES (2, N'年糕', 10000, 1, NULL, 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[T_ProType] OFF
/****** Object:  Table [dbo].[T_Products]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Products]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProName] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ProModel] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ProGrade] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ProAreas] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ProWeight] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ProPackage] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ProStorage] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ShelfLife] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Content] [ntext] COLLATE Chinese_PRC_CI_AS NULL,
	[ProTip] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[KeyWords] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[NoteTime] [datetime] NULL,
	[ProPic] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ProPic1] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ProPic2] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ProPic3] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ProPic4] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[Price] [decimal](18, 2) NULL,
	[Price1] [decimal](18, 2) NULL,
	[IsShow] [int] NULL,
	[IsNew] [int] NULL,
	[IsRecommend] [int] NULL,
	[SID] [int] NULL,
	[TypeID] [int] NULL,
	[Links] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[Hits] [int] NULL,
	[SaleNum] [int] NULL,
	[Seo_Title] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Seo_Keywords] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Seo_Description] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Seo_Author] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_T_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Products', N'COLUMN',N'ProGrade'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Products', @level2type=N'COLUMN',@level2name=N'ProGrade'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Products', N'COLUMN',N'ProAreas'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产地' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Products', @level2type=N'COLUMN',@level2name=N'ProAreas'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Products', N'COLUMN',N'ProWeight'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'重量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Products', @level2type=N'COLUMN',@level2name=N'ProWeight'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Products', N'COLUMN',N'ProPackage'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Products', @level2type=N'COLUMN',@level2name=N'ProPackage'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Products', N'COLUMN',N'ShelfLife'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保质期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Products', @level2type=N'COLUMN',@level2name=N'ShelfLife'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Products', N'COLUMN',N'Content'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存储' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Products', @level2type=N'COLUMN',@level2name=N'Content'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Products', N'COLUMN',N'Price'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Products', @level2type=N'COLUMN',@level2name=N'Price'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Products', N'COLUMN',N'Price1'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市场价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Products', @level2type=N'COLUMN',@level2name=N'Price1'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Products', N'COLUMN',N'SaleNum'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'已经售出数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Products', @level2type=N'COLUMN',@level2name=N'SaleNum'
GO
/****** Object:  Table [dbo].[T_OrderFormStatus]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_OrderFormStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_OrderFormStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeCalled] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[IsShow] [int] NULL,
	[SID] [int] NULL,
	[Memo] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_T_OrderFormStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderFormStatus', N'COLUMN',N'TypeCalled'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderFormStatus', @level2type=N'COLUMN',@level2name=N'TypeCalled'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderFormStatus', N'COLUMN',N'IsShow'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderFormStatus', @level2type=N'COLUMN',@level2name=N'IsShow'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderFormStatus', N'COLUMN',N'SID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SID排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderFormStatus', @level2type=N'COLUMN',@level2name=N'SID'
GO
SET IDENTITY_INSERT [dbo].[T_OrderFormStatus] ON
INSERT [dbo].[T_OrderFormStatus] ([ID], [TypeCalled], [IsShow], [SID], [Memo]) VALUES (1, N'提交订单', 1, 10000, N'下单完成，我们会在1个工作日内打电话给您核实！')
INSERT [dbo].[T_OrderFormStatus] ([ID], [TypeCalled], [IsShow], [SID], [Memo]) VALUES (2, N'确认订单', 1, 10000, N'订单已经确认，请点击这里付款！&nbsp;<input type="button" id="btPay" name="btPay" value="我要付款" onclick="GotoPay()" />')
INSERT [dbo].[T_OrderFormStatus] ([ID], [TypeCalled], [IsShow], [SID], [Memo]) VALUES (3, N'已付款', 1, 10000, N'付款成功！我们会在1个工作日内发货！')
INSERT [dbo].[T_OrderFormStatus] ([ID], [TypeCalled], [IsShow], [SID], [Memo]) VALUES (4, N'已经发货', 1, 10000, N'您购买的商品已经发货，请注意查收！')
INSERT [dbo].[T_OrderFormStatus] ([ID], [TypeCalled], [IsShow], [SID], [Memo]) VALUES (5, N'完成', 1, 10000, N'订单已经完成！')
INSERT [dbo].[T_OrderFormStatus] ([ID], [TypeCalled], [IsShow], [SID], [Memo]) VALUES (6, N'退订', 1, 10000, N'您已经成功退订！')
SET IDENTITY_INSERT [dbo].[T_OrderFormStatus] OFF
/****** Object:  Table [dbo].[T_OrderForm]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_OrderForm]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_OrderForm](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProID] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[NoteTime] [datetime] NULL,
	[ProName] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[Price] [decimal](18, 2) NULL,
	[UserID] [int] NULL,
	[UserName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Mobile] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Tel] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Fax] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Address] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[EMail] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[Company] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[Detail] [nvarchar](4000) COLLATE Chinese_PRC_CI_AS NULL,
	[IsBilling] [int] NULL,
	[Memo] [ntext] COLLATE Chinese_PRC_CI_AS NULL,
	[PriceLog] [ntext] COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Status] [int] NULL,
	[IsPay] [int] NULL,
	[PayPrice] [decimal](18, 2) NULL,
 CONSTRAINT [PK_T_OrderForm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'ProID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'ProID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'NoteTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'NoteTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'ProName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订购产品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'ProName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'Price'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'Price'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'UserID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'UserID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'UserName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订购人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'UserName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'Mobile'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订购人手机号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'Tel'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订购人固定电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'Tel'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'Fax'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订购人传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'Fax'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'Address'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'Address'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'EMail'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子邮件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'EMail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'Company'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'Company'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'Detail'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单明细' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'Detail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'IsBilling'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否开票' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'IsBilling'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'Memo'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'Memo'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'PriceLog'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格修改记录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'PriceLog'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'Status'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单子状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'Status'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'IsPay'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已经支付' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'IsPay'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_OrderForm', N'COLUMN',N'PayPrice'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_OrderForm', @level2type=N'COLUMN',@level2name=N'PayPrice'
GO
/****** Object:  Table [dbo].[T_NewType]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_NewType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_NewType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeCalled] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SID] [int] NULL,
	[IsShow] [int] NULL,
	[PID] [int] NULL,
	[Pic] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_T_NewType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[T_NewType] ON
INSERT [dbo].[T_NewType] ([ID], [TypeCalled], [SID], [IsShow], [PID], [Pic]) VALUES (1, N'新闻动态', 10000, 1, 0, NULL)
SET IDENTITY_INSERT [dbo].[T_NewType] OFF
/****** Object:  Table [dbo].[T_News]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_News]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_News](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[NoteTime] [datetime] NULL,
	[NewPic] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[NewTip] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Content] [ntext] COLLATE Chinese_PRC_CI_AS NULL,
	[IsShow] [int] NULL,
	[SID] [int] NULL,
	[KeyWords] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[NewType] [int] NULL,
	[Hits] [int] NULL,
	[IsRecommend] [int] NULL,
	[Author] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Origin] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Seo_Title] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Seo_Keywords] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Seo_Description] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Seo_Author] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[Url] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_T_News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[T_News] ON
INSERT [dbo].[T_News] ([ID], [Title], [NoteTime], [NewPic], [NewTip], [Content], [IsShow], [SID], [KeyWords], [NewType], [Hits], [IsRecommend], [Author], [Origin], [Seo_Title], [Seo_Keywords], [Seo_Description], [Seo_Author], [Url]) VALUES (174, N'咖啡飘香，负氧迷情-双12全民共庆加利弗咖啡馆盛大开业', CAST(0x0000A4360140EB60 AS DateTime), NULL, NULL, NULL, 1, 10000, NULL, 1, 0, 1, NULL, NULL, N'咖啡飘香，负氧迷情-双12全民共庆加利弗咖啡馆盛大开业', NULL, NULL, NULL, NULL)
INSERT [dbo].[T_News] ([ID], [Title], [NoteTime], [NewPic], [NewTip], [Content], [IsShow], [SID], [KeyWords], [NewType], [Hits], [IsRecommend], [Author], [Origin], [Seo_Title], [Seo_Keywords], [Seo_Description], [Seo_Author], [Url]) VALUES (175, N'咖啡飘香，负氧迷情-双12全民共庆加利弗咖啡馆盛大开业', CAST(0x0000A4360140F2B0 AS DateTime), NULL, NULL, NULL, 1, 10000, NULL, 1, 0, 1, NULL, NULL, N'咖啡飘香，负氧迷情-双12全民共庆加利弗咖啡馆盛大开业', NULL, NULL, NULL, NULL)
INSERT [dbo].[T_News] ([ID], [Title], [NoteTime], [NewPic], [NewTip], [Content], [IsShow], [SID], [KeyWords], [NewType], [Hits], [IsRecommend], [Author], [Origin], [Seo_Title], [Seo_Keywords], [Seo_Description], [Seo_Author], [Url]) VALUES (176, N'咖啡飘香，负氧迷情-双12全民共庆加利弗咖啡馆盛大开业', CAST(0x0000A4360140F405 AS DateTime), NULL, NULL, NULL, 1, 10000, NULL, 1, 0, 1, NULL, NULL, N'咖啡飘香，负氧迷情-双12全民共庆加利弗咖啡馆盛大开业', NULL, NULL, NULL, NULL)
INSERT [dbo].[T_News] ([ID], [Title], [NoteTime], [NewPic], [NewTip], [Content], [IsShow], [SID], [KeyWords], [NewType], [Hits], [IsRecommend], [Author], [Origin], [Seo_Title], [Seo_Keywords], [Seo_Description], [Seo_Author], [Url]) VALUES (177, N'咖啡飘香，负氧迷情-双12全民共庆加利弗咖啡馆盛大开业', CAST(0x0000A4360140F61D AS DateTime), NULL, NULL, NULL, 1, 10000, NULL, 1, 0, 1, NULL, NULL, N'咖啡飘香，负氧迷情-双12全民共庆加利弗咖啡馆盛大开业', NULL, NULL, NULL, NULL)
INSERT [dbo].[T_News] ([ID], [Title], [NoteTime], [NewPic], [NewTip], [Content], [IsShow], [SID], [KeyWords], [NewType], [Hits], [IsRecommend], [Author], [Origin], [Seo_Title], [Seo_Keywords], [Seo_Description], [Seo_Author], [Url]) VALUES (178, N'fafasfasdfasdfasdfas', CAST(0x0000A436014150B7 AS DateTime), N'images/img.jpg', N'　　2014年12月11日，经过数月的紧张筹备，宁波首家负氧离子
咖啡馆——加利弗咖啡馆隆重开业，成功掀起了一股"净氧呼
吸，乐活主义"的负氧离子风潮。', N'<div>　　2014年12月11日，经过数月的紧张筹备，宁波首家负氧离子<br />
咖啡馆&mdash;&mdash;加利弗咖啡馆隆重开业，成功掀起了一股&quot;净氧呼<br />
吸，乐活主义&quot;的负氧离子风潮。</div>', 1, 10000, N'', 1, 0, 1, N'', N'', N'咖啡飘香，负氧迷情-双12全民共庆加利弗咖啡馆盛大开业', N'', N'', N'', NULL)
SET IDENTITY_INSERT [dbo].[T_News] OFF
/****** Object:  Table [dbo].[T_LinkType]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_LinkType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_LinkType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SID] [int] NULL,
	[TypeCalled] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_T_LinkType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_LinkType', N'COLUMN',N'SID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_LinkType', @level2type=N'COLUMN',@level2name=N'SID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_LinkType', N'COLUMN',N'TypeCalled'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_LinkType', @level2type=N'COLUMN',@level2name=N'TypeCalled'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_LinkType', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_LinkType'
GO
SET IDENTITY_INSERT [dbo].[T_LinkType] ON
INSERT [dbo].[T_LinkType] ([ID], [SID], [TypeCalled]) VALUES (1, 10000, N'首页焦点图')
SET IDENTITY_INSERT [dbo].[T_LinkType] OFF
/****** Object:  Table [dbo].[T_Link]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Link]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Link](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Called] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SID] [int] NULL,
	[Pic] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[Link] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[TypeID] [int] NULL,
	[IsShow] [int] NULL,
	[NoteTime] [datetime] NULL,
	[IsShowOther] [int] NULL,
 CONSTRAINT [PK_T_Link] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Link', N'COLUMN',N'Called'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接文字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Link', @level2type=N'COLUMN',@level2name=N'Called'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Link', N'COLUMN',N'SID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Link', @level2type=N'COLUMN',@level2name=N'SID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Link', N'COLUMN',N'Pic'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片地址URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Link', @level2type=N'COLUMN',@level2name=N'Pic'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Link', N'COLUMN',N'Link'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Link', @level2type=N'COLUMN',@level2name=N'Link'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Link', N'COLUMN',N'TypeID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Link', @level2type=N'COLUMN',@level2name=N'TypeID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Link', N'COLUMN',N'IsShow'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Link', @level2type=N'COLUMN',@level2name=N'IsShow'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Link', N'COLUMN',N'NoteTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'录入时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Link', @level2type=N'COLUMN',@level2name=N'NoteTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Link', N'COLUMN',N'IsShowOther'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否在其他页面中显示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Link', @level2type=N'COLUMN',@level2name=N'IsShowOther'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Link', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Link'
GO
SET IDENTITY_INSERT [dbo].[T_Link] ON
INSERT [dbo].[T_Link] ([ID], [Called], [SID], [Pic], [Link], [TypeID], [IsShow], [NoteTime], [IsShowOther]) VALUES (1, N'焦点图1', 10000, N'images/index_12.jpg', N'#', 1, 1, CAST(0x0000A43600E39564 AS DateTime), 0)
INSERT [dbo].[T_Link] ([ID], [Called], [SID], [Pic], [Link], [TypeID], [IsShow], [NoteTime], [IsShowOther]) VALUES (2, N'焦点图2', 10000, N'images/index_12.jpg', N'#', 1, 1, CAST(0x0000A43600E3AD77 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[T_Link] OFF
/****** Object:  Table [dbo].[T_JM]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_JM]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_JM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeID] [int] NULL,
	[Sex] [int] NULL,
	[UserName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Birthday] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[BirthPlace] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Age] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Tel] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Tel1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Fax] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[QQ] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Mail] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Area] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[UserID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Linkman] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Tel2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Sales] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Products] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[StartDate] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ShopGoodwill] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ShopAddress] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[Address] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[Memo] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[Suggest] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[NoteTime] [datetime] NULL,
 CONSTRAINT [PK_T_JM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[T_Info]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Info]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Info](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SID] [int] NULL,
	[Called] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Memo] [ntext] COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_T_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[T_Info] ON
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (1, 10000, N'底部版权', N'宁波阿拉桐桐餐饮管理有限公司 地址：宁波市海曙区中山西路75号鼓楼大厦1023室<br/>
联系方式：4000-0784-18    0574-87341101<br/>
COPYRIGHT(C) 2006 tongtong-food.com ALL RIGHT RESERVED.   ')
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (2, 10000, N'底部二维码', N'<a href="#"><img src="images/index_33.jpg" width="59" height="59" /></a>')
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (3, 10000, N'关于我们', N'<div style="float:right; position:relative; padding-left:20px;"><img src="images/about_06.jpg" width="353" height="198" /></div>
　　宁波阿拉桐餐饮管理有限公司是一家专业的整合
技术开发公司，主营时尚饮品、精致点心的产品研发，
品牌营销及招商加盟。公司已成功帮助上千位小额投
资者成功开店创业。公司以明确的市场定位、以点带
面的发展模式严谨经营。<br/><br/>
　　阿拉桐桐隶属于宁波阿拉桐餐饮管理有限公司，
作为成功的本土连锁品牌，在现今各行商业圈都被圈
外企业占据的局面下，我们致力于突破客户"崇外"
的思想，以精挑细选的原材料制作出让客户满意的口味。<br/><br/>
　　谁说米线（米粉）店就一定是低端、简陋的街边小店？谁说吃米线就是屌丝的专属格调？米线店也可以充满特色、
十分时尚。饮行业已经从传统的"味道竞争"转变成了"体验竞争"，作为食尚都市概念·米线（米粉）连锁品牌，阿
拉桐桐无论从其装修设计、菜单还是餐品上，都充满了年轻与欢乐的元素，让消费者在食尚优雅的环境中品尝风味绝
佳的米线、米粉及其他美味佳肴，食尚美食轻松享受。<br/><br/>

 
<div align="center"><img src="images/about_11.jpg" width="714" height="283" /></div>')
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (4, 10000, N'联系我们', N'		<div><img src="images/contact_03.jpg" width="382" height="43" /></div>
		宁波阿拉桐桐餐饮管理有限公司 <br/>
宁波总公司地址：宁波市海曙区中山西路75号鼓楼大厦1023室<br/>
联系方式：0574-87341101<br/><br/> 
<div align="center">
<style type="text/css">
    html,body{margin:0;padding:0;}
    .iw_poi_title {color:#CC5522;font-size:14px;font-weight:bold;overflow:hidden;padding-right:13px;white-space:nowrap}
    .iw_poi_content {font:12px arial,sans-serif;overflow:visible;padding-top:4px;white-space:-moz-pre-wrap;word-wrap:break-word}
</style>
<script type="text/javascript" src="http://api.map.baidu.com/api?key=&v=1.1&services=true"></script>

  <!--百度地图容器-->
  <div style="width:697px;height:550px;border:#ccc solid 1px;" id="dituContent"></div>
<script type="text/javascript">
    //创建和初始化地图函数：
    function initMap(){
        createMap();//创建地图
        setMapEvent();//设置地图事件
        addMapControl();//向地图添加控件
        addMarker();//向地图中添加marker
    }
    
    //创建地图函数：
    function createMap(){
        var map = new BMap.Map("dituContent");//在百度地图容器中创建一个地图
        var point = new BMap.Point(121.553565,29.879354);//定义一个中心点坐标
        map.centerAndZoom(point,16);//设定地图的中心点和坐标并将地图显示在地图容器中
        window.map = map;//将map变量存储在全局
    }
    
    //地图事件设置函数：
    function setMapEvent(){
        map.enableDragging();//启用地图拖拽事件，默认启用(可不写)
        map.enableScrollWheelZoom();//启用地图滚轮放大缩小
        map.enableDoubleClickZoom();//启用鼠标双击放大，默认启用(可不写)
        map.enableKeyboard();//启用键盘上下左右键移动地图
    }
    
    //地图控件添加函数：
    function addMapControl(){
        //向地图中添加缩放控件
	var ctrl_nav = new BMap.NavigationControl({anchor:BMAP_ANCHOR_TOP_LEFT,type:BMAP_NAVIGATION_CONTROL_LARGE});
	map.addControl(ctrl_nav);
                //向地图中添加比例尺控件
	var ctrl_sca = new BMap.ScaleControl({anchor:BMAP_ANCHOR_BOTTOM_LEFT});
	map.addControl(ctrl_sca);
    }
    
    //标注点数组
    var markerArr = [{title:"宁波阿拉桐桐餐饮管理有限公司",content:"宁波总公司地址：宁波市海曙区中山西路75号鼓楼大厦1023室<br/>联系方式：0574-87341101",point:"121.554302|29.878853",isOpen:0,icon:{w:23,h:25,l:46,t:21,x:9,lb:12}}
		 ];
    //创建marker
    function addMarker(){
        for(var i=0;i<markerArr.length;i++){
            var json = markerArr[i];
            var p0 = json.point.split("|")[0];
            var p1 = json.point.split("|")[1];
            var point = new BMap.Point(p0,p1);
			var iconImg = createIcon(json.icon);
            var marker = new BMap.Marker(point,{icon:iconImg});
			var iw = createInfoWindow(i);
			var label = new BMap.Label(json.title,{"offset":new BMap.Size(json.icon.lb-json.icon.x+10,-20)});
			marker.setLabel(label);
            map.addOverlay(marker);
            label.setStyle({
                        borderColor:"#808080",
                        color:"#333",
                        cursor:"pointer"
            });
			
			(function(){
				var index = i;
				var _iw = createInfoWindow(i);
				var _marker = marker;
				_marker.addEventListener("click",function(){
				    this.openInfoWindow(_iw);
			    });
			    _iw.addEventListener("open",function(){
				    _marker.getLabel().hide();
			    })
			    _iw.addEventListener("close",function(){
				    _marker.getLabel().show();
			    })
				label.addEventListener("click",function(){
				    _marker.openInfoWindow(_iw);
			    })
				if(!!json.isOpen){
					label.hide();
					_marker.openInfoWindow(_iw);
				}
			})()
        }
    }
    //创建InfoWindow
    function createInfoWindow(i){
        var json = markerArr[i];
        var iw = new BMap.InfoWindow("<b class=''iw_poi_title'' title=''" + json.title + "''>" + json.title + "</b><div class=''iw_poi_content''>"+json.content+"</div>");
        return iw;
    }
    //创建一个Icon
    function createIcon(json){
        var icon = new BMap.Icon("http://app.baidu.com/map/images/us_mk_icon.png", new BMap.Size(json.w,json.h),{imageOffset: new BMap.Size(-json.l,-json.t),infoWindowOffset:new BMap.Size(json.lb+5,1),offset:new BMap.Size(json.x,json.h)})
        return icon;
    }
    
    initMap();//创建和初始化地图
</script>
</div><br/>
<div style="padding-left:20px;">
<font color="#f2331f" size="3">门店地址：</font><br/>
宁波分店地址：宁波市海曙区公园路20号1楼<br/>
联系方式：0574-87341101<br/>
-------------------------------------------------------------------------------------------<br/>
常州分店地址：常州市钟楼区延陵西路150号1楼<br/>
联系方式：0574-87341101<br/>
-------------------------------------------------------------------------------------------<br/>
上海总店地址：黄河路97号<br/>
联系方式：0574-87341101<br/>
------------------------------------------------------------------------------------------- <br/>
上海分店地址：陕西北路678号<br/>
联系方式：0574-87341101<br/>
-------------------------------------------------------------------------------------------<br/>
上海分店地址：宁波路178号<br/>
联系方式：0574-87341101<br/>
-------------------------------------------------------------------------------------------<br/>
上海分店地址：吴江路269号湟普汇2楼<br/>
联系方式：0574-87341101<br/>
-------------------------------------------------------------------------------------------<br/>
上海分点地址：浙江中路486号<br/>
联系方式：0574-87341101<br/>
</div>
	')
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (5, 10000, N'首页关于我们图片', N'<a href="about.aspx"><img alt="阿拉桐" height="82" src="images/index_19.jpg" width="141" /></a>')
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (6, 10000, N'首页关于我们文字', N'阿拉桐桐诞生于1994年，在上海的吴江路上。曾经20元买来的一个汽油桶做成火炉，支起一付生煎摊...')
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (7, 10000, N'加盟条件', N'<div><strong><span style="color: #ff8c00">选址条件（具体以合同为准）</span></strong><br />
一、首选一楼，如在其他楼层，艺龙有迎宾入口为佳<br />
二、店面至少要40平米以上；<br />
三、停车方便有适当停车场所；<br />
四、如开分店要离原址有一定距离；<br />
五、租赁合同年限达3年以上啊。</div><div>&nbsp;</div><div style="position: relative; float: right"><img src="images/ppic_03.jpg" /></div><div><strong><span style="color: #ff8c00">最佳选址条件</span></strong><br />
一、大型成熟的购物中心和商场内；<br />
二、大型成熟的写字楼和繁华商业楼复合区；<br />
三、人员流动性大的区域，如火车站、汽车站等；<br />
四、大型的工业聚集区；<br />
五、高等院校密集区域；<br />
六、同类餐饮火爆区域。</div>
')
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (8, 10000, N'投资预算', N'<div align="center"><img src="images/ppic_04.jpg" /></div>')
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (9, 10000, N'加盟流程', N'<div align="center"><img src="images/pp_07.jpg" width="579" height="304" /></div>')
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (10, 10000, N'加盟支持', N'<div>1.选址评估，打好开店基础<br />
总部专业人员会对加盟商目标店面进行实地详细的调查，并且对周边的建筑、商圈、人流、消费能力、竞争对手情况作全面的评<br />
估，制定相应的营销策略指导，协助加盟店做好开店关键一步。<br />
2.专业团队，保证开店顺利<br />
完善的开店流程及加盟开业指导，会帮助加盟店迅速进入开业准备状态，对装修进行指导，同时对人员招募、物料的准备等各方<br />
面工作也会做针对性的指导，确保高效、有序开业。<br />
3.品牌形象，系统专业支持<br />
提供全套阿拉桐品牌形象、店面形象系统支持，提供专业设计与店铺形象规划，并协助筹备加盟店。提供第一手市场信息和趋势<br />
预测，及品牌形象宣传推广支持。<br />
4.系统培训，全面助力成长<br />
由具有多年餐厅经营管理经验的专门培训人员对学员进行培训，结合理论和实践相结合的培训方式，培训地点设在公司直营店内，<br />
能够更好的学习在实际经营中如何解决问题，保证加盟店的高效运行。<br />
5.营运知道，持续提升业绩<br />
在加盟店经营期间，总部运营部门会每月对门店进行定期巡检，针对门店经营和管理的各种问题，给予加盟商和门店人员正对性<br />
的辅导，帮助加盟店管理品质的稳定，以利于稳定持久的提高业绩。<br />
6.产品研发，不断创新改进<br />
阿拉桐拥有目前国内油流的研发团队，定期针对餐饮市场的动向、先进设备、产品趋势、口味特色等进行研究。定期退出适合市<br />
场的新品种，以确保客户对阿拉桐保持持续的新鲜感，提升顾客忠诚度。<br />
7.贴心指导，不断完善提高<br />
早开业前后，总部都将派专人到点贴心帮扶指导，实地指导经营及操作，并结合加盟店所在城市及商圈情况，制定开店推广及宣<br />
传促销计划。开业后，总部将持续加强与加盟商之间的沟通，不断完善提高。</div>')
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (11, 10000, N'加盟问答', N'<img src="images/book_03.jpg" width="724" height="199" />')
INSERT [dbo].[T_Info] ([ID], [SID], [Called], [Memo]) VALUES (12, 10000, N'流程说明', N'流程说明：<br />

1.有投资意向者可通过电话向总部了解具体事宜，本人也可以直接来总部品尝、考察。<br />

2.店铺地址应选在人流量较大，消费水平相对稳定，店面位置较显眼的地方，面积在50-120平米之间，租金
  在每平方米200元以上。<br />

3.向总部提出申请后，总部根据申请地域的市场环境、消费情况和申请者自身条件予以审核，并对投资预算、
  投资回报、经营状况及持续经营潜力等进行评估分析。申请受理、资格审核。<br />

4.加盟协议是在双方本着平等自愿、互惠互利、共同发展的原则下，明确双方责、权、利的合作细则。<br />

5.支付相关费用、拟订培训计划、食宿安排。<br />

6.加盟者须派两个人前往总部培训一个星期，学习店内的基本操作。<br />

7.按照总部的店面设计方案，在总部的指导下进行店面装修，包括店内布置、牌匾、统一的店面形象。<br />

8.做好开业准备。选择开业日期。平时开业建议选择星期五，星期六，星期日。<br />

9.免费提供长期经营辅导和管理咨询服务，提供加盟后续物料供应及店内辅导。')
SET IDENTITY_INSERT [dbo].[T_Info] OFF
/****** Object:  Table [dbo].[T_Book]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Book]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Book](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[RealName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Title] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NULL,
	[NoteTime] [datetime] NULL,
	[EMail] [nvarchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[Tel] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Company] [nvarchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[Memo] [ntext] COLLATE Chinese_PRC_CI_AS NULL,
	[Reply] [ntext] COLLATE Chinese_PRC_CI_AS NULL,
	[ReplyTime] [datetime] NULL,
	[IP] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[IsShow] [int] NULL,
	[IsRecommend] [int] NULL,
	[SID] [int] NULL,
	[QQ] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Fax] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Address] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_T_Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Book', N'COLUMN',N'RealName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Book', @level2type=N'COLUMN',@level2name=N'RealName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Book', N'COLUMN',N'Title'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Book', @level2type=N'COLUMN',@level2name=N'Title'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Book', N'COLUMN',N'NoteTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'录入时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Book', @level2type=N'COLUMN',@level2name=N'NoteTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Book', N'COLUMN',N'EMail'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Book', @level2type=N'COLUMN',@level2name=N'EMail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Book', N'COLUMN',N'Tel'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Book', @level2type=N'COLUMN',@level2name=N'Tel'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Book', N'COLUMN',N'Company'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Book', @level2type=N'COLUMN',@level2name=N'Company'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Book', N'COLUMN',N'Memo'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Book', @level2type=N'COLUMN',@level2name=N'Memo'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Book', N'COLUMN',N'IP'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ip地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Book', @level2type=N'COLUMN',@level2name=N'IP'
GO
SET IDENTITY_INSERT [dbo].[T_Book] ON
INSERT [dbo].[T_Book] ([ID], [UserID], [RealName], [Title], [NoteTime], [EMail], [Tel], [Company], [Memo], [Reply], [ReplyTime], [IP], [IsShow], [IsRecommend], [SID], [QQ], [Fax], [Address]) VALUES (1, 0, N'', N'FFFF', CAST(0x0000A43B00BAA15B AS DateTime), N'', N'', NULL, N'AAAAA', N'', CAST(0x0000A43B00BAC930 AS DateTime), NULL, 1, 1, 10000, N'', NULL, N'')
SET IDENTITY_INSERT [dbo].[T_Book] OFF
/****** Object:  Table [dbo].[T_AdminMenu]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_AdminMenu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_AdminMenu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[Link] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[IsShow] [int] NULL,
	[PID] [int] NULL,
	[SID] [int] NULL,
	[AdminUser] [nvarchar](1024) COLLATE Chinese_PRC_CI_AS NOT NULL,
 CONSTRAINT [PK_T_AdminMenu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[T_AdminMenu] ON
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (1, N'高级管理选项', N'images/Admin_left_04.gif', 1, 0, 10, N'|1||1|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (2, N'管理员用户管理', N'admin.aspx', 1, 1, 11, N'|1||1|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (3, N'后台菜单管理', N'adminmenu.aspx', 1, 1, 12, N'|1|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (4, N'网站推广入口', N'images/Admin_left_10.gif', 1, 0, 10000, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (5, N'百度登录入口 ', N'http://www.baidu.com/search/url_submit.html', 1, 4, 10000, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (6, N'Google登录入口', N'http://www.google.com/intl/zh-CN/add_url.html', 1, 4, 10000, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (7, N'Yahoo登录入口', N'http://search.help.cn.yahoo.com/h4_4.html', 1, 4, 10000, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (8, N'Bing登录入口', N'http://search.msn.com/docs/submit.aspx', 1, 4, 10000, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (9, N'Alexa登录入口', N'http://www.alexa.com/site/help/webmasters', 1, 4, 10000, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (10, N'有道登录入口', N'http://tellbot.youdao.com/report?keyFrom=help', 1, 4, 10000, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (11, N'搜搜登录入口', N'http://www.soso.com/help/usb/urlsubmit.shtml', 1, 4, 10000, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (12, N'搜狗登录入口', N'http://www.sogou.com/feedback/urlfeedback.php', 1, 4, 10000, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (13, N'中搜登录入口', N'http://ads.zhongsou.com/register/page.jsp', 1, 4, 10000, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (14, N'SEO优化管理', N'images/Admin_left_05.gif', 1, 0, 80, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (15, N'各栏目关键词', N'seo.aspx', 1, 14, 81, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (16, N'生成静态页面', N'SysInfo.aspx', 1, 14, 83, N'|2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (17, N'网站信息设置', N'images/Admin_left_01.gif', 1, 0, 20, N'|1||2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (18, N'用户密码管理', N'password_mod.aspx', 1, 17, 21, N'|1||2||2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (19, N'网站首页管理', N'images/Admin_left_08.gif', 1, 0, 30, N'|2||2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (20, N'首页关于我们图片', N'info.aspx?id=5', 1, 19, 31, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (21, N'首页关于我们文字', N'info.aspx?id=6', 1, 19, 32, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (22, N'首页推荐产品', N'products.aspx?IsRecommend=1', 1, 19, 33, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (23, N'首页新闻推荐', N'news.aspx?NewType=1&IsRecommend=1', 1, 19, 34, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (24, N'加盟流程', N'info.aspx?id=9', 1, 27, 51, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (25, N'底部版权文字', N'info.aspx?id=1', 1, 17, 23, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (26, N'加盟支持', N'info.aspx?id=10', 1, 27, 52, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (27, N'网站栏目管理', N'images/Admin_left_13.gif', 1, 0, 40, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (28, N'选购常识', N'news.aspx?NewType=7', 0, 19, 41, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (29, N'关于我们', N'info.aspx?id=3', 1, 27, 42, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (30, N'联系我们', N'info.aspx?id=4', 1, 27, 43, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (31, N'品牌介绍', N'info.aspx?id=5', 0, 27, 44, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (32, N'新闻动态', N'news.aspx?NewType=1', 1, 27, 45, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (33, N'美食推荐', N'products.aspx', 1, 27, 46, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (34, N'首页问答推荐', N'book.aspx?IsRecommend=1', 1, 19, 40, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (35, N'加盟条件', N'info.aspx?id=7', 1, 27, 48, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (37, N'投资预算', N'info.aspx?id=8', 1, 27, 50, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (38, N'友情链接管理', N'images/Admin_left_06.gif', 0, 0, 60, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (39, N'首页焦点图', N'link.aspx?TypeID=1', 1, 38, 61, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (40, N'加盟问答', N'info.aspx?id=11', 1, 27, 53, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (41, N'不显示菜单', N'images/Admin_left_03.gif', 1, 0, 10000, N'')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (42, N'新闻分类管理', N'newtype.aspx', 1, 41, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (43, N'产品分类管理', N'protype.aspx', 1, 41, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (44, N'流程说明', N'info.aspx?id=12', 1, 27, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (45, N'问答FAQ', N'book.aspx', 1, 27, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (51, N'招商信息', N'info.aspx?id=7', 0, 27, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (56, N'合作流程', N'info.aspx?id=8', 0, 27, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (58, N'底部菜单', N'link.aspx?TypeID=2', 0, 38, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (59, N'底部二维码', N'info.aspx?id=2', 1, 17, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (60, N'语言栏目管理', N'images/Admin_left_02.gif', 0, 0, 59, N'')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (61, N'西班牙语最新资讯', N'news.aspx?NewType=13', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (62, N'西班牙语语言中心', N'news.aspx?NewType=14', 0, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (63, N'西班牙留学', N'news.aspx?NewType=15', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (64, N'西班牙语就业', N'news.aspx?NewType=16', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (65, N'西班牙风情', N'news.aspx?NewType=17', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (66, N'法语最新资讯', N'news.aspx?NewType=18', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (67, N'法语语言中心', N'news.aspx?NewType=19', 0, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (68, N'法国留学', N'news.aspx?NewType=20', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (69, N'法语就业', N'news.aspx?NewType=21', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (70, N'法国风情', N'news.aspx?NewType=22', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (71, N'德语最新资讯', N'news.aspx?NewType=23', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (72, N'德语语言中心', N'news.aspx?NewType=24', 0, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (73, N'德国留学', N'news.aspx?NewType=25', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (74, N'德语就业', N'news.aspx?NewType=26', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (75, N'德国风情', N'news.aspx?NewType=27', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (76, N'日语最新资讯', N'news.aspx?NewType=28', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (77, N'日语语言中心', N'news.aspx?NewType=29', 0, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (78, N'日本留学', N'news.aspx?NewType=30', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (79, N'日语就业', N'news.aspx?NewType=31', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (80, N'日本风情', N'news.aspx?NewType=32', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (81, N'意大利语最新资讯', N'news.aspx?NewType=33', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (82, N'意大利语语言中心', N'news.aspx?NewType=34', 0, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (83, N'意大利留学', N'news.aspx?NewType=35', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (84, N'意大利语就业', N'news.aspx?NewType=36', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (85, N'意大利风情', N'news.aspx?NewType=37', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (86, N'韩语最新资讯', N'news.aspx?NewType=38', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (87, N'韩语语言中心', N'news.aspx?NewType=39', 0, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (88, N'韩国留学', N'news.aspx?NewType=40', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (89, N'韩语就业', N'news.aspx?NewType=41', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (90, N'韩国风情', N'news.aspx?NewType=42', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (91, N'俄语最新资讯', N'news.aspx?NewType=43', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (92, N'俄语语言中心', N'news.aspx?NewType=44', 0, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (93, N'俄罗斯留学', N'news.aspx?NewType=45', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (94, N'俄语就业', N'news.aspx?NewType=46', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (95, N'俄罗斯风情', N'news.aspx?NewType=47', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (96, N'葡萄牙语最新资讯', N'news.aspx?NewType=48', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (97, N'葡萄牙语语言中心', N'news.aspx?NewType=49', 0, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (98, N'葡萄牙留学', N'news.aspx?NewType=50', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (99, N'葡萄牙语就业', N'news.aspx?NewType=51', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (100, N'葡萄牙风情', N'news.aspx?NewType=52', 1, 60, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (101, N'焦点图', N'news.aspx?NewType=1', 0, 17, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (103, N'代理商风采', N'news.aspx?newtype=8', 0, 27, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (104, N'资料下载', N'news.aspx?NewType=9', 0, 27, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (105, N'联系方式', N'info.aspx?id=9', 0, 27, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (106, N'精英团队', N'info.aspx?id=10', 0, 27, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (107, N'加入我们', N'info.aspx?id=11', 0, 27, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (108, N'资质证明栏目', N'info.aspx?id=16', 0, 27, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (109, N'防伪查询栏目', N'info.aspx?id=17', 0, 27, 10000, N'|2|')
INSERT [dbo].[T_AdminMenu] ([ID], [Title], [Link], [IsShow], [PID], [SID], [AdminUser]) VALUES (110, N'人才招聘栏目', N'info.aspx?id=18', 0, 27, 10000, N'|2|')
SET IDENTITY_INSERT [dbo].[T_AdminMenu] OFF
/****** Object:  Table [dbo].[T_Admin]    Script Date: 02/10/2015 12:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Admin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[PassWord] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[IsLock] [int] NULL,
	[UserRole] [int] NULL,
	[UserRoleCalled] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[UserMenu] [nvarchar](2048) COLLATE Chinese_PRC_CI_AS NOT NULL,
 CONSTRAINT [PK_T_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Admin', N'COLUMN',N'UserMenu'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Admin', @level2type=N'COLUMN',@level2name=N'UserMenu'
GO
SET IDENTITY_INSERT [dbo].[T_Admin] ON
INSERT [dbo].[T_Admin] ([ID], [UserName], [PassWord], [IsLock], [UserRole], [UserRoleCalled], [UserMenu]) VALUES (1, N'admin', N'e1316babcc351c568d0e1c321adbafd3', 0, 255, N'系统管理员', N'|1||2||3||17||18|')
INSERT [dbo].[T_Admin] ([ID], [UserName], [PassWord], [IsLock], [UserRole], [UserRoleCalled], [UserMenu]) VALUES (2, N'user', N'253f208d5b063dc50c017d5cc199d276', 0, 0, N'后台用户', N'|17||18||24||25||19||20||21||22||23||14||15||16||4||5||6||7||8||9||10||11||12||13||27||28||29||30||31||32||33||34||35||36||37||38||39||38||40||42||43||24||25||20||21||22||23||28||29||30||32||31||32||33||34||33||34||34||33||35||36||37||24||40||44||45||46||47||47||48||49||50||52||52||53||54||55||57||39||58||59||61||62||63||64||65||66||67||68||69||70||71||72||73||74||75||76||77||78||79||80||81||82||83||84||85||86||87||88||89||90||91||92||93||94||95||96||97||98||99||100||34||35||44||47||52||101||101||25||59||101||20||21||22||23||34||28||29||30||31||32||31||33||35||37||24||26||40||44||45||102||30||31||32||33||35||37||24||26||40||44||45||103||104||104||105||106||107||108||109||110||108||109||25||29||30||31||32||33||35||37||24||35||26||40||51||59||59||101||20||29||30||31||32||33||35||37||24||26||101||20||21||22||22||29||30||31||32||33||35||37||24||26||40||44||59||20||21||22||23||34||30||31||32||33||35||37||24||26||40||44||45||51||56||103||104||105||106||107||39||59||20||21||23||34||29||30||32||33||35||37||24||26||40||44||45||22|')
SET IDENTITY_INSERT [dbo].[T_Admin] OFF
/****** Object:  StoredProcedure [dbo].[PageByRowNumber]    Script Date: 02/10/2015 12:03:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PageByRowNumber]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE proc [dbo].[PageByRowNumber]
(
@pageIndex int=1,
@pageSize int=10,
@tableName nvarchar(50),
@where nvarchar(max),
@orderby nvarchar(50),
@RecordCount  int = 0 output
)
AS
DECLARE @startRow int, @endRow int,@strSql varchar(Max),@strRsSql nvarchar(max)
Set @startRow = (@pageIndex - 1) * @pageSize +1
SET @endRow = @startRow + @pageSize -1 
set @strSql=''SELECT * FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY ''+@orderby+'') AS RowNumber FROM [''+@tableName+'']''+@where+'') T WHERE T.RowNumber BETWEEN ''+LTrim(str(@startRow))+'' AND ''+LTrim(str(@endRow))
exec (@strSql)

---统计记录
set @strRsSql=''select @RecordCount=count(ID) from [''+@tableName+''] ''+@where+''''
EXEC sp_executesql @strRsSql,N''@RecordCount int out'',@RecordCount out



' 
END
GO
/****** Object:  View [dbo].[V_Products]    Script Date: 02/10/2015 12:03:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_Products]'))
EXEC dbo.sp_executesql @statement = N'

CREATE VIEW [dbo].[V_Products]
AS
SELECT     dbo.T_ProType.TypeCalled, dbo.T_ProType.PID,dbo.T_ProType.Tip as TypeTip, dbo.T_Products.*
FROM         dbo.T_ProType RIGHT OUTER JOIN
                      dbo.T_Products ON dbo.T_ProType.ID = dbo.T_Products.TypeID

'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'V_Products', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "T_ProType"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 172
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_Products"
            Begin Extent = 
               Top = 6
               Left = 210
               Bottom = 121
               Right = 368
            End
            DisplayFlags = 280
            TopColumn = 18
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 21
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Products'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'V_Products', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Products'
GO
/****** Object:  View [dbo].[V_OrderForm]    Script Date: 02/10/2015 12:03:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_OrderForm]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_OrderForm]
AS
SELECT     dbo.T_OrderFormStatus.TypeCalled, dbo.T_OrderForm.ID, dbo.T_OrderForm.ProID, dbo.T_OrderForm.NoteTime, dbo.T_OrderForm.ProName, 
                      dbo.T_OrderForm.Price, dbo.T_OrderForm.UserName, dbo.T_OrderForm.Mobile, dbo.T_OrderForm.Tel, dbo.T_OrderForm.Fax, 
                      dbo.T_OrderForm.Address, dbo.T_OrderForm.EMail, dbo.T_OrderForm.Company, dbo.T_OrderForm.Detail, dbo.T_OrderForm.IsBilling, 
                      dbo.T_OrderForm.Memo, dbo.T_OrderForm.PriceLog, dbo.T_OrderForm.Status, dbo.T_OrderForm.IsPay, dbo.T_OrderForm.PayPrice, 
                      dbo.T_OrderFormStatus.Memo AS TypeMemo, dbo.T_OrderForm.UserID
FROM         dbo.T_OrderFormStatus RIGHT OUTER JOIN
                      dbo.T_OrderForm ON dbo.T_OrderFormStatus.ID = dbo.T_OrderForm.Status
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'V_OrderForm', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "T_OrderFormStatus"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 172
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_OrderForm"
            Begin Extent = 
               Top = 6
               Left = 210
               Bottom = 121
               Right = 341
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OrderForm'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'V_OrderForm', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OrderForm'
GO
/****** Object:  View [dbo].[V_News]    Script Date: 02/10/2015 12:03:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_News]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_News]
AS
SELECT     dbo.T_NewType.TypeCalled, dbo.T_NewType.PID, dbo.T_News.ID, dbo.T_News.SID, dbo.T_News.Title, dbo.T_News.NoteTime, dbo.T_News.[Content], 
                      dbo.T_News.KeyWords, dbo.T_News.Hits, dbo.T_News.IsRecommend, dbo.T_News.Author, dbo.T_News.Origin, dbo.T_News.NewType, 
                      dbo.T_News.IsShow, dbo.T_News.NewPic, dbo.T_News.NewTip, dbo.T_News.Seo_Title, dbo.T_News.Seo_Keywords, dbo.T_News.Seo_Description, 
                      dbo.T_News.Seo_Author, dbo.T_SEO.PageName, dbo.T_News.Url
FROM         dbo.T_NewType LEFT OUTER JOIN
                      dbo.T_SEO ON dbo.T_NewType.TypeCalled = dbo.T_SEO.PageNameCalled RIGHT OUTER JOIN
                      dbo.T_News ON dbo.T_NewType.ID = dbo.T_News.NewType
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'V_News', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "T_NewType"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 172
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_SEO"
            Begin Extent = 
               Top = 69
               Left = 517
               Bottom = 251
               Right = 677
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_News"
            Begin Extent = 
               Top = 6
               Left = 210
               Bottom = 121
               Right = 368
            End
            DisplayFlags = 280
            TopColumn = 15
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_News'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'V_News', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_News'
GO
/****** Object:  View [dbo].[V_Link]    Script Date: 02/10/2015 12:03:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_Link]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_Link]
AS
SELECT     dbo.T_LinkType.TypeCalled, dbo.T_Link.ID, dbo.T_Link.Called, dbo.T_Link.SID, dbo.T_Link.Pic, dbo.T_Link.Link, dbo.T_Link.TypeID, 
                      dbo.T_Link.IsShow, dbo.T_Link.NoteTime, dbo.T_Link.IsShowOther
FROM         dbo.T_Link LEFT OUTER JOIN
                      dbo.T_LinkType ON dbo.T_Link.TypeID = dbo.T_LinkType.ID
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'V_Link', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "T_Link"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 182
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_LinkType"
            Begin Extent = 
               Top = 6
               Left = 220
               Bottom = 106
               Right = 354
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Link'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'V_Link', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Link'
GO
/****** Object:  Default [DF_T_Admin_IsLock]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Admin_IsLock]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Admin]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Admin_IsLock]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Admin] ADD  CONSTRAINT [DF_T_Admin_IsLock]  DEFAULT ((0)) FOR [IsLock]
END


End
GO
/****** Object:  Default [DF_T_Admin_UserRole]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Admin_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Admin]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Admin_UserRole]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Admin] ADD  CONSTRAINT [DF_T_Admin_UserRole]  DEFAULT ((0)) FOR [UserRole]
END


End
GO
/****** Object:  Default [DF_T_AdminMenu_IsShow]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_AdminMenu_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_AdminMenu]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_AdminMenu_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_AdminMenu] ADD  CONSTRAINT [DF_T_AdminMenu_IsShow]  DEFAULT ((1)) FOR [IsShow]
END


End
GO
/****** Object:  Default [DF_T_AdminMenu_PID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_AdminMenu_PID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_AdminMenu]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_AdminMenu_PID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_AdminMenu] ADD  CONSTRAINT [DF_T_AdminMenu_PID]  DEFAULT ((0)) FOR [PID]
END


End
GO
/****** Object:  Default [DF_T_AdminMenu_SID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_AdminMenu_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_AdminMenu]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_AdminMenu_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_AdminMenu] ADD  CONSTRAINT [DF_T_AdminMenu_SID]  DEFAULT ((10000)) FOR [SID]
END


End
GO
/****** Object:  Default [DF_T_Book_UserID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Book_UserID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Book]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Book_UserID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Book] ADD  CONSTRAINT [DF_T_Book_UserID]  DEFAULT ((0)) FOR [UserID]
END


End
GO
/****** Object:  Default [DF_T_Book_NoteTime]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Book_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Book]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Book_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Book] ADD  CONSTRAINT [DF_T_Book_NoteTime]  DEFAULT (getdate()) FOR [NoteTime]
END


End
GO
/****** Object:  Default [DF_T_Book_IsShow]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Book_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Book]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Book_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Book] ADD  CONSTRAINT [DF_T_Book_IsShow]  DEFAULT ((0)) FOR [IsShow]
END


End
GO
/****** Object:  Default [DF_T_Book_IsRecommend]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Book_IsRecommend]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Book]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Book_IsRecommend]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Book] ADD  CONSTRAINT [DF_T_Book_IsRecommend]  DEFAULT ((0)) FOR [IsRecommend]
END


End
GO
/****** Object:  Default [DF_T_Book_SID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Book_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Book]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Book_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Book] ADD  CONSTRAINT [DF_T_Book_SID]  DEFAULT ((10000)) FOR [SID]
END


End
GO
/****** Object:  Default [DF_T_Info_SID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Info_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Info]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Info_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Info] ADD  CONSTRAINT [DF_T_Info_SID]  DEFAULT ((10000)) FOR [SID]
END


End
GO
/****** Object:  Default [DF_T_JM_TypeID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_JM_TypeID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_JM]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_JM_TypeID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_JM] ADD  CONSTRAINT [DF_T_JM_TypeID]  DEFAULT ((0)) FOR [TypeID]
END


End
GO
/****** Object:  Default [DF_T_JM_NoteTime]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_JM_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_JM]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_JM_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_JM] ADD  CONSTRAINT [DF_T_JM_NoteTime]  DEFAULT (getdate()) FOR [NoteTime]
END


End
GO
/****** Object:  Default [DF_T_Link_SID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Link_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Link]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Link_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Link] ADD  CONSTRAINT [DF_T_Link_SID]  DEFAULT ((10000)) FOR [SID]
END


End
GO
/****** Object:  Default [DF_T_Link_TypeID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Link_TypeID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Link]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Link_TypeID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Link] ADD  CONSTRAINT [DF_T_Link_TypeID]  DEFAULT ((0)) FOR [TypeID]
END


End
GO
/****** Object:  Default [DF_T_Link_IsShow]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Link_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Link]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Link_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Link] ADD  CONSTRAINT [DF_T_Link_IsShow]  DEFAULT ((1)) FOR [IsShow]
END


End
GO
/****** Object:  Default [DF_T_Link_NoteTime]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Link_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Link]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Link_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Link] ADD  CONSTRAINT [DF_T_Link_NoteTime]  DEFAULT (getdate()) FOR [NoteTime]
END


End
GO
/****** Object:  Default [DF_T_Link_IsShowOther]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Link_IsShowOther]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Link]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Link_IsShowOther]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Link] ADD  CONSTRAINT [DF_T_Link_IsShowOther]  DEFAULT ((0)) FOR [IsShowOther]
END


End
GO
/****** Object:  Default [DF_T_LinkType_SID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_LinkType_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_LinkType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_LinkType_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_LinkType] ADD  CONSTRAINT [DF_T_LinkType_SID]  DEFAULT ((10000)) FOR [SID]
END


End
GO
/****** Object:  Default [DF_T_News_NoteTime]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] ADD  CONSTRAINT [DF_T_News_NoteTime]  DEFAULT (getdate()) FOR [NoteTime]
END


End
GO
/****** Object:  Default [DF_T_News_IsShow]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] ADD  CONSTRAINT [DF_T_News_IsShow]  DEFAULT ((1)) FOR [IsShow]
END


End
GO
/****** Object:  Default [DF_T_News_SID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] ADD  CONSTRAINT [DF_T_News_SID]  DEFAULT ((10000)) FOR [SID]
END


End
GO
/****** Object:  Default [DF_T_News_NewType]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_NewType]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_NewType]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] ADD  CONSTRAINT [DF_T_News_NewType]  DEFAULT ((0)) FOR [NewType]
END


End
GO
/****** Object:  Default [DF_T_News_Hits]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_Hits]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_Hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] ADD  CONSTRAINT [DF_T_News_Hits]  DEFAULT ((0)) FOR [Hits]
END


End
GO
/****** Object:  Default [DF_T_News_IsRecommend]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_News_IsRecommend]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_News_IsRecommend]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_News] ADD  CONSTRAINT [DF_T_News_IsRecommend]  DEFAULT ((0)) FOR [IsRecommend]
END


End
GO
/****** Object:  Default [DF_T_NewType_SID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_NewType_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_NewType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_NewType_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_NewType] ADD  CONSTRAINT [DF_T_NewType_SID]  DEFAULT ((10000)) FOR [SID]
END


End
GO
/****** Object:  Default [DF_T_NewType_IsShow]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_NewType_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_NewType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_NewType_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_NewType] ADD  CONSTRAINT [DF_T_NewType_IsShow]  DEFAULT ((1)) FOR [IsShow]
END


End
GO
/****** Object:  Default [DF_T_NewType_PID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_NewType_PID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_NewType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_NewType_PID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_NewType] ADD  CONSTRAINT [DF_T_NewType_PID]  DEFAULT ((0)) FOR [PID]
END


End
GO
/****** Object:  Default [DF_T_OrderForm_ProID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_ProID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_ProID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] ADD  CONSTRAINT [DF_T_OrderForm_ProID]  DEFAULT ((0)) FOR [ProID]
END


End
GO
/****** Object:  Default [DF_T_OrderForm_NoteTime]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] ADD  CONSTRAINT [DF_T_OrderForm_NoteTime]  DEFAULT (getdate()) FOR [NoteTime]
END


End
GO
/****** Object:  Default [DF_T_OrderForm_Price]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_Price]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_Price]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] ADD  CONSTRAINT [DF_T_OrderForm_Price]  DEFAULT ((0)) FOR [Price]
END


End
GO
/****** Object:  Default [DF_T_OrderForm_UserID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_UserID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_UserID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] ADD  CONSTRAINT [DF_T_OrderForm_UserID]  DEFAULT ((0)) FOR [UserID]
END


End
GO
/****** Object:  Default [DF_T_OrderForm_IsBilling]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_IsBilling]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_IsBilling]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] ADD  CONSTRAINT [DF_T_OrderForm_IsBilling]  DEFAULT ((0)) FOR [IsBilling]
END


End
GO
/****** Object:  Default [DF_T_OrderForm_Status]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_Status]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_Status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] ADD  CONSTRAINT [DF_T_OrderForm_Status]  DEFAULT ((0)) FOR [Status]
END


End
GO
/****** Object:  Default [DF_T_OrderForm_IsPay]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_IsPay]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_IsPay]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] ADD  CONSTRAINT [DF_T_OrderForm_IsPay]  DEFAULT ((0)) FOR [IsPay]
END


End
GO
/****** Object:  Default [DF_T_OrderForm_PayPrice]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderForm_PayPrice]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderForm]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderForm_PayPrice]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderForm] ADD  CONSTRAINT [DF_T_OrderForm_PayPrice]  DEFAULT ((0)) FOR [PayPrice]
END


End
GO
/****** Object:  Default [DF_T_OrderFormStatus_IsShow]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderFormStatus_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderFormStatus]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderFormStatus_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderFormStatus] ADD  CONSTRAINT [DF_T_OrderFormStatus_IsShow]  DEFAULT ((1)) FOR [IsShow]
END


End
GO
/****** Object:  Default [DF_T_OrderFormStatus_SID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_OrderFormStatus_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_OrderFormStatus]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_OrderFormStatus_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_OrderFormStatus] ADD  CONSTRAINT [DF_T_OrderFormStatus_SID]  DEFAULT ((10000)) FOR [SID]
END


End
GO
/****** Object:  Default [DF_T_Products_NoteTime]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] ADD  CONSTRAINT [DF_T_Products_NoteTime]  DEFAULT (getdate()) FOR [NoteTime]
END


End
GO
/****** Object:  Default [DF_T_Products_IsShow]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] ADD  CONSTRAINT [DF_T_Products_IsShow]  DEFAULT ((1)) FOR [IsShow]
END


End
GO
/****** Object:  Default [DF_T_Products_IsNew]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_IsNew]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_IsNew]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] ADD  CONSTRAINT [DF_T_Products_IsNew]  DEFAULT ((0)) FOR [IsNew]
END


End
GO
/****** Object:  Default [DF_T_Products_IsRecommend]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_IsRecommend]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_IsRecommend]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] ADD  CONSTRAINT [DF_T_Products_IsRecommend]  DEFAULT ((0)) FOR [IsRecommend]
END


End
GO
/****** Object:  Default [DF_T_Products_SID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] ADD  CONSTRAINT [DF_T_Products_SID]  DEFAULT ((10000)) FOR [SID]
END


End
GO
/****** Object:  Default [DF_T_Products_TypeID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_TypeID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_TypeID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] ADD  CONSTRAINT [DF_T_Products_TypeID]  DEFAULT ((0)) FOR [TypeID]
END


End
GO
/****** Object:  Default [DF_T_Products_Hits]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_Hits]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_Hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] ADD  CONSTRAINT [DF_T_Products_Hits]  DEFAULT ((0)) FOR [Hits]
END


End
GO
/****** Object:  Default [DF_T_Products_SaleNum]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Products_SaleNum]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Products]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Products_SaleNum]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_Products] ADD  CONSTRAINT [DF_T_Products_SaleNum]  DEFAULT ((0)) FOR [SaleNum]
END


End
GO
/****** Object:  Default [DF_T_ProType_SID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_ProType_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_ProType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_ProType_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_ProType] ADD  CONSTRAINT [DF_T_ProType_SID]  DEFAULT ((10000)) FOR [SID]
END


End
GO
/****** Object:  Default [DF_T_ProType_IsShow]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_ProType_IsShow]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_ProType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_ProType_IsShow]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_ProType] ADD  CONSTRAINT [DF_T_ProType_IsShow]  DEFAULT ((1)) FOR [IsShow]
END


End
GO
/****** Object:  Default [DF_T_ProType_PID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_ProType_PID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_ProType]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_ProType_PID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_ProType] ADD  CONSTRAINT [DF_T_ProType_PID]  DEFAULT ((0)) FOR [PID]
END


End
GO
/****** Object:  Default [DF_T_User_UserType]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_UserType]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_UserType]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] ADD  CONSTRAINT [DF_T_User_UserType]  DEFAULT ((0)) FOR [UserType]
END


End
GO
/****** Object:  Default [DF_T_User_NoteTime]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_NoteTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_NoteTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] ADD  CONSTRAINT [DF_T_User_NoteTime]  DEFAULT (getdate()) FOR [NoteTime]
END


End
GO
/****** Object:  Default [DF_T_User_LoginTime]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_LoginTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_LoginTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] ADD  CONSTRAINT [DF_T_User_LoginTime]  DEFAULT (getdate()) FOR [LoginTime]
END


End
GO
/****** Object:  Default [DF_T_User_AreaID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_AreaID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_AreaID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] ADD  CONSTRAINT [DF_T_User_AreaID]  DEFAULT ((0)) FOR [AreaID]
END


End
GO
/****** Object:  Default [DF_T_User_AreaID1]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_AreaID1]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_AreaID1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] ADD  CONSTRAINT [DF_T_User_AreaID1]  DEFAULT ((0)) FOR [AreaID1]
END


End
GO
/****** Object:  Default [DF_T_User_IsLock]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_IsLock]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_IsLock]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] ADD  CONSTRAINT [DF_T_User_IsLock]  DEFAULT ((0)) FOR [IsLock]
END


End
GO
/****** Object:  Default [DF_T_User_Sex]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_Sex]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_Sex]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] ADD  CONSTRAINT [DF_T_User_Sex]  DEFAULT ((1)) FOR [Sex]
END


End
GO
/****** Object:  Default [DF_T_User_SID]    Script Date: 02/10/2015 12:03:48 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_User_SID]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_User]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_User_SID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_User] ADD  CONSTRAINT [DF_T_User_SID]  DEFAULT ((10000)) FOR [SID]
END


End
GO
