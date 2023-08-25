# Job-Home
It's a desktop application for students to find jobs and accommodations and learn about careers. It's also a platform for HRs and the owners of houses to upload their resources and chances.

## 1. Intro

### 1. Project background

In the 21st century, information surrounds us, scattered across various platforms. Whether you're seeking current affairs on Zhihu, fashion trends on Redbook, or job opportunities on 51job, the wealth of information can be overwhelming.

As a soon-to-be graduate entering the workforce, you've likely experienced the challenge of juggling multiple platforms to find both a job and a place to live. These decisions are closely intertwined. Imagine securing your dream job only to struggle with finding suitable housing nearby, impacting your daily commute and overall satisfaction.

Job&Home is here to simplify your life. We've brought job and housing opportunities together on one platform, making it easy to compare and make informed decisions. We understand that your work and housing choices affect many aspects of your life. That's why we've created a solution that helps you consider the bigger picture, enabling you to achieve the perfect balance between work and housing.

### 2. Purpose of project design

Based on the above project background introduction, the "one-stop solution platform for graduates" hopes to be "people-oriented,” consider the actual needs of a specific group of people, and fully consider the human behavior process, which is the basic value in the design. We hope to try this concept creatively: reconnecting and interacting with information fully subdivided by Internet platforms. Provide social-oriented learning content so that fresh graduates can better understand their jobs and inspire new job ideas; users who are looking for a job can compare the basic information of the job and the available housing sources near the job; let Users who choose a house can learn about the facilities and environment near the house through the map; users in the same university and with the same major recommend each other so that fresh graduates can get help by contacting alumni, helping students to be more competitive in the workplace. In the Internet of Everything", we believe that relevant information for a series of needs of specific users can also be interconnected to create new possibilities.

## 2. Main functions

The system mainly serves college students who are about to graduate and enter the workforce, helping them find housing and jobs and finding suitable rental and recruitment targets for landlords and companies in need.

For different types of users, the function settings are also different. For landlords and company users, the main functions include posting information, modifying and deleting information, and interacting with student users (online chat, resume checking). For college students, the main function is to filter out suitable housing information by setting the desired housing type, price, decoration, etc., and also provide map information and the function of contacting the landlord online for specific housing. Expected welfare screening to obtain job information, you can submit resumes online; provide browsing, like, and collection functions for articles, allowing users to understand relevant information from multiple angles; in addition, we also envisage adding "university circles" in further development " function to meet the social needs of student users.

## 3. Database design

### 3.1. Analysis of data requirements

The graduation season takes the majority of graduates as the user group and simultaneously provides a platform for landlords and companies to release information. Landlords and companies can publish listing information and job information on the platform. In addition, an article browsing function is also provided for users, and users can browse and collect experience articles related to job hunting. Therefore, it is necessary to collect information about six objects: users (graduates), landlords, companies, published listings, published jobs, and articles. Users, landlords, and companies need to log in with account numbers, passwords, and other relevant information; housing sources need to have housing-related information, such as address, price, etc.; jobs need to have information such as salary, work address, benefits, etc.; articles need to have titles, content, etc. information.

### 3.2. Conceptual model design (E-R diagram design)

  According to program design needs and data demand analysis, make the following E-R diagram:

![img](D:/WZXZ/%E6%95%B0%E6%8D%AE%E5%BA%93%EF%BC%88%E6%96%B0%E6%96%87%E4%BB%B6%E5%A4%B9%EF%BC%89/Job_Home/pic/E-R%20diagram.png)

### 3.3. Logic pattern design

Convert E-R diagram to relational schema:
Listing (<u>serial number</u>, longitude, latitude, name, rent, apartment type, area, fine decoration, elevator, parking space, gas)
Landlord (<u>landlord account number</u>, password, name, phone number)
Property ownership (<u>serial number</u>, <u>landlord account number</u>)
Job (<u>company name</u>, <u>position</u>, <u>address</u>, benefits, work area and county, salary, education, major, job content, work experience)
Company (<u>company name</u>, password)
User (<u>user account</u>, password, university, major, real name, gender, graduation year)
Article (<u>title</u>, content, author, likes)
Resume (<u>company name</u>, <u>position</u>, <u>address</u>, <u>user account</u>, resume)
Information (l<u>andlord account</u>, <u>user account</u>, <u>time</u>, message content, sender)
favorite(<u>user_account</u>, <u>title</u>)

房源（<u>序号</u>，经度，纬度，名称，租金，户型，面积，精装修，电梯，车位，燃气）

房东（<u>房东账号</u>，密码，姓名，电话）

房产拥有（<u>序号</u>，<u>房东账号</u>）

工作（<u>公司名</u>，<u>岗位</u>，<u>地址</u>，福利，工作区县，薪资，学历，专业，工作内容，工作经验）

公司（<u>公司名</u>，密码）

用户(<u>用户账号</u>，密码，大学，专业，真实姓名，性别，毕业年份)

文章（<u>标题</u>，内容，作者，赞数）

投递简历（<u>公司名</u>，<u>岗位</u>，<u>地址</u>，<u>用户账号</u>，简历）

信息（<u>房东账号</u>，<u>用户账号</u>，<u>时间</u>，信息内容，发送方）

收藏（<u>用户账号</u>，<u>标题</u>）

### 3.4. Standardized processing

After analysis, this pattern satisfies the third normal form **(3NF)**. Considering that the relevant attributes may be different in different companies, different positions, or different work locations, there is no partial functional dependency and transfer function dependency in the "work" entity, which belongs to the three paradigms; the same analysis for other entities also belongs to the first Three paradigms.

### 3.5. Create table and integrity control

Created tables (some tables are generated by importing data, create tables by editing table codes in import data-edit mapping, the following is the table script code)

```
CREATE TABLE [dbo].[house](
	[index1] [nvarchar](255) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[x] [float] NOT NULL,
	[y] [float] NOT NULL,
	[prise] [float] NOT NULL,
	[户型] [nvarchar](255) NULL,
	[面积] [nvarchar](255) NULL,
	[有无精装修] [nvarchar](255) NULL,
	[有无电梯] [nvarchar](255) NULL,
	[有无车位] [nvarchar](255) NULL,
	[有无燃气] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[index1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

```

```
CREATE TABLE [dbo].[landlord](
	[LID] [nvarchar](255) NOT NULL,
	[LPASS] [nvarchar](255) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[tel] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

```

```
③创建房产拥有表：
CREATE TABLE [dbo].[owned](
	[index1] [nvarchar](255) NOT NULL,
	[LID] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[index1] ASC,
	[LID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[owned]  WITH CHECK ADD FOREIGN KEY([index1])
REFERENCES [dbo].[house] ([index1])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[owned]  WITH CHECK ADD FOREIGN KEY([LID])
REFERENCES [dbo].[landlord] ([LID])
ON DELETE CASCADE
GO



④创建工作表：
CREATE TABLE [dbo].[work](
	[job] [nvarchar](255) NOT NULL,
	[salary] [nvarchar](255) NULL,
	[workexp] [nvarchar](255) NULL,
	[edu] [nvarchar](255) NULL,
	[major] [nvarchar](255) NULL,
	[welfare] [nvarchar](255) NULL,
	[detail] [nvarchar](max) NULL,
	[place] [nvarchar](255) NOT NULL,
	[company] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[job] ASC,
	[place] ASC,
	[company] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[work]  WITH CHECK ADD  CONSTRAINT [FK_work_hr] FOREIGN KEY([company])
REFERENCES [dbo].[hr] ([cname])
GO
ALTER TABLE [dbo].[work] CHECK CONSTRAINT [FK_work_hr]
GO



⑤创建公司表：
CREATE TABLE [dbo].[hr](
	[cname] [nvarchar](255) NOT NULL,
	[cpass] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



⑥创建用户表：
CREATE TABLE [dbo].[users](
	[username] [varchar](30) NOT NULL,
	[usermm] [varchar](20) NOT NULL,
	[userpic] [varchar](50) NOT NULL,
	[realname] [varchar](50) NULL,
	[sex] [varchar](4) NULL,
	[birthday] [date] NULL,
	[university] [varchar](50) NULL,
	[major] [varchar](50) NULL,
	[gradyear] [varchar](4) NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD CHECK  (([username] like '[a-z]%'))
GO



⑦创建文章表：
CREATE TABLE [dbo].[information](
	[title] [varchar](80) NOT NULL,
	[textall] [varchar](5000) NOT NULL,
	[author] [varchar](30) NULL,
	[good] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



⑧创建简历表：
CREATE TABLE [dbo].[resume](
	[username] [varchar](30) NOT NULL,
	[job] [nvarchar](255) NOT NULL,
	[company] [nvarchar](255) NOT NULL,
	[place] [nvarchar](255) NOT NULL,
	[resfile] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[resume]  WITH CHECK ADD FOREIGN KEY([job], [place], [company])
REFERENCES [dbo].[work] ([job], [place], [company])
GO
ALTER TABLE [dbo].[resume]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[users] ([username])
GO



⑨创建信息表：
create table ulmessage
([username] [varchar](30) NOT NULL foreign key references users(username) on delete cascade,
[LID] nvarchar(255) NOT NULL foreign key references landlord(LID) on delete cascade,
mes nvarchar(255) not null,
times datetime not null,
sending int not null check(sending in (1,2)),
primary key(username,LID,times))



⑩创建收藏表：
CREATE TABLE [dbo].[usermark](
	[username] [varchar](30) NOT NULL,
	[title] [varchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC,
	[title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[usermark]  WITH CHECK ADD FOREIGN KEY([title])
REFERENCES [dbo].[information] ([title])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[usermark]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[users] ([username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[usermark]  WITH CHECK ADD CHECK  (([username] like '[a-z]%'))
GO

```

![img](D:/WZXZ/%E6%95%B0%E6%8D%AE%E5%BA%93%EF%BC%88%E6%96%B0%E6%96%87%E4%BB%B6%E5%A4%B9%EF%BC%89/Job_Home/pic/relational%20tables.png)

#### 3.6 Trigger

The database in this project mainly uses entity integrity constraints and referential integrity constraints, plus static constraints of check, and triggers are not used for constraints.



## 4. Form design and function design

(1) Enter the program animation interface
(2) Main interface of "Gas Station-Find Job-Find Housing"
(3) Article detailed browsing interface 
(4) My home page 
(5) My favorite interface 
(6) House information interface 
(8) Work details interface 
(9) Landlord function selection interface 
(10) Landlord's new listings 
(11) The landlord updates and modifies the listing interface 
(12) Landlord's "My Homepage" interface 
(13) Company function selection interface 
(14) New post interface 
(15) Update and delete published post information interface 
(16) Resume delivery interface 
(17) User login interface 
(18) User registration interface 
(19) User chat function interface 
(20) Landlord chat function interface 

## 5. System testing 

#### Landlord addition, deletion and modification function test 

房东成功登陆后选择增添新的房源信息

![img](./pic/clip_image002.jpg)

添加同济大学的一户房源信息

![img](./pic/clip_image004.jpg)

 

![img](./pic/clip_image005.png)

将电梯改成无，面积改成150平方米

![img](./pic/clip_image006.png)

关闭窗体后再进入，信息成功更新

![img](./pic/clip_image007.png)

点击确认删除，成功删除该条数据

![img](./pic/clip_image008.png)

#### The company's addition, deletion and modification function test 

登陆后新增数据

![img](./pic/clip_image002-1692999808696-21.jpg)

进入修改、更新界面查看数据；新增数据成功录入

![img](./pic/clip_image003.png)

更新操作

![img](./pic/clip_image004.png)

删除操作后，成功删除

![img](./pic/clip_image005-1692999808696-22.png)

#### Resume delivery view function test 

用户登陆后选择一个到一个工作

![img](./pic/clip_image002-1692999888779-27.jpg)

![img](./pic/clip_image003-1692999888780-28.png)![img](./pic/clip_image004-1692999888780-29.png)![img](./pic/clip_image005-1692999888781-30.png)

退出登陆后，公司账号登陆，选择查看简历

![img](./pic/clip_image007.jpg)![img](./pic/clip_image009.jpg)

在查看简历中，可以看到用户投递的简历。

#### User article and home page function test 

搜索功能测试：输入“行业”关键字，自动筛选含有该关键字的文章，按赞数降序排列

![img](./pic/clip_image002-1692999908487-39.jpg)

点开文章，可以点赞或收藏

![img](./pic/clip_image003-1692999908484-38.png)

点击收藏，收藏的文章可以在我的主页中查看；打开我的主页-我的收藏，查看收藏的文章

![img](./pic/clip_image004-1692999908487-40.png)

![img](./pic/clip_image005-1692999908484-37.png)

![img](./pic/clip_image006-1692999908490-41.png)

在我的主页中可以修改个人信息

![img](./pic/clip_image007-1692999908492-42.png)

![img](./pic/clip_image008-1692999908493-43.png)

#### User job search function test 

用户勾选想要的工作选项：

![img](./pic/clip_image002-1692999925013-51.jpg)

![img](./pic/clip_image004-1692999925013-52.jpg)

点击具体工作可以查看详情、投递简历

![img](./pic/clip_image005-1692999925014-53.png)

同时推荐工作地点附近的房源

![img](./pic/clip_image006-1692999925015-54.png)

点击房源可以跳转房源页面查看房源详细信息，可以联系房东、查看地图。

![img](./pic/clip_image007-1692999925018-55.png)

#### Function test of users looking for housing 

选择找住房功能，勾选想要的功能

![img](./pic/clip_image002-1692999939202-63.jpg)

![img](./pic/clip_image004-1692999939201-61.jpg)

单击可以查看详细信息、地图和联系房东

![img](./pic/clip_image005-1692999939202-62.png)

#### User landlord chat function test 

用户看中心仪房源后可在线联系房东

![img](./pic/clip_image002-1692999953538-68.jpg)

房东可在个人主页界面查看用户发送的消息并予以回复

**![img](./pic/clip_image003-1692999953537-67.png)**

### 6. Evaluation

#### This program has the following advantages and features:

- With strong pertinence and wide audience, functions are designed for the three groups of graduate users, companies and landlords.
- The interface is easy to understand, and you can get started quickly without tutorials and help.
- Powerful functions, providing a communication platform for landlords and users, and providing a resume delivery function for graduate users.
- With graduate users as the core, the sharing of experience articles in the "Gas Station" helps fresh graduates grow.
- Be considerate of users, introduce the Baidu map function, locate the housing location and provide the housing information closest to the job according to this,
- The source of data is authentic and reliable, and the published housing and recruitment information is crawled from the Internet, and the database is supported by a large amount of data

#### This program has the following room for improvement:

- Entity attributes in the database design can add more detailed constraints, and triggers can also be added (such as triggering prompts when the format of the user's mailbox is wrong), etc. Database function design can be further enhanced.
- The interface design is not refined enough, the property and job search interface is alternately gray and white, and colors can be added, etc.
- The information provided is not comprehensive and accurate. For example, the housing source can provide further information such as specific pictures of the housing source, floors, etc., and the company can further provide information such as working environment photos, contact numbers, and WeChat.