create table users
(
username varchar(30) not null primary key,
usermm varchar(20) not null check(len(usermm)>=6),
userpic varchar(50) not null

)

create table usermark
(
username varchar(30) not null foreign key references.users ,
title  varchar(80) NOT NULL foreign key references.information
)

create table usergood
(
username varchar(30) not null foreign key references.users ,
title  varchar(80) NOT NULL foreign key references.information
)

