CREATE TABLE "Passport"
(
    Number varchar(50) NOT NULL PRIMARY KEY ,
    Type   varchar(50)
);

CREATE TABLE "Department"
(
    Name  varchar(100) NOT NULL ,
    Phone varchar(20),
    Id    serial PRIMARY KEY
);

CREATE TABLE "Employee"
(
    Id             serial PRIMARY KEY,
    Name           varchar(50),
    Surname        varchar(50),
    Phone          varchar(20),
    CompanyId      integer,
    PassportNumber varchar(50) constraint fk_employee_passport references public."Passport",
    DepartmentId   integer constraint fk_employee_department references public."Department"
);

INSERT INTO public."Department"(
    "name", "phone")
values ('Отдел маркетинга', '+79324765396'),
       ('Отдел разработки', '+79835456372'),
       ('Отдел аналитики', '+79512546547');

INSERT INTO public."Passport"(
    "number", "type")
values ('123', 'passport'),
       ('321', 'passport'),
       ('999', 'passport'),
       ('777', 'passport'),
       ('111', 'passport');

INSERT INTO public."Employee"(
    "name", "surname", "phone", "companyid", "passportnumber", "departmentid")
values ('Иван', 'Иванов', '+7932473556', '1', '123', '1'),
       ('Петр', 'Волков', '+7932474654', '2', '321', '1'),
       ('Тест', 'Тестов', '+7932147841', '1', '999', '2'),
       ('Максим', 'Максимов', '+79321474841', '1', '777', '2'),
       ('Анна', 'Козлова', '+793255567', '3', '111', '3');
