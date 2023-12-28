/*==============================================================*/
/* DBMS name:      ORACLE Version 19c                           */
/* Created on:     28.12.2023 15:38:52                          */
/*==============================================================*/


alter table AIM
   drop constraint FK_AIM_HAT_USER;

alter table APPOINTMENT
   drop constraint FK_APPOINTM_APPOINTME_EMPLOYEE;

alter table APPOINTMENT
   drop constraint FK_APPOINTM_USER_APPO_USER;

alter table EMPLOYEE
   drop constraint FK_EMPLOYEE_EMPLOYEE__AUTHORIZ;

alter table EMPLOYEE_RECIPE
   drop constraint FK_EMPLOYEE_IS_MANAGE_EMPLOYEE;

alter table EMPLOYEE_RECIPE
   drop constraint FK_EMPLOYEE_MANAGES_RECIPE;

alter table EMPLOYEE_SPORT
   drop constraint FK_EMPLOYEE_CREATED_SPORT;

alter table EMPLOYEE_SPORT
   drop constraint FK_EMPLOYEE_IS_CREATE_EMPLOYEE;

alter table EMPLOYEE_TRAINING_PLAN
   drop constraint FK_EMPLOYEE_IS_MANAGE_EMPLOYEE;

alter table EMPLOYEE_TRAINING_PLAN
   drop constraint FK_EMPLOYEE_MANAGES2_TRAINING;

alter table EXERCISE
   drop constraint FK_EXERCISE_EXERCISE__TRAINING;

alter table EXERCISE_CATEGORY
   drop constraint FK_EXERCISE_BELONGS_T_CATEGORY;

alter table EXERCISE_CATEGORY
   drop constraint FK_EXERCISE_CONTAINS5_EXERCISE;

alter table EXERCISE_SPORT
   drop constraint FK_EXERCISE_CONTAINS3_EXERCISE;

alter table EXERCISE_SPORT
   drop constraint FK_EXERCISE_IS_PART_O_SPORT;

alter table EXERCISE_UNIT
   drop constraint FK_EXERCISE_CONTAINS6_EXERCISE;

alter table EXERCISE_UNIT
   drop constraint FK_EXERCISE_IS_A_PART_TRAINING;

alter table FITNESSLEVEL
   drop constraint FK_FITNESSL_HAS_USER;

alter table INGRIDIENT
   drop constraint FK_INGRIDIE_BELONGS_QUANTITY;

alter table QUANTITYPRICE
   drop constraint FK_QUANTITY_HAS2_INGRIDIE;

alter table RECIPE
   drop constraint FK_RECIPE_RECIPE_CA_RECIPECA;

alter table RECIPE
   drop constraint FK_RECIPE_USER_RECI_USER;

alter table RECIPE_APPOINTMENT
   drop constraint FK_RECIPE_A_CONTAINS4_RECIPE;

alter table RECIPE_APPOINTMENT
   drop constraint FK_RECIPE_A_IS_IN_APPOINTM;

alter table RECIPE_INGRIDIENT
   drop constraint FK_RECIPE_I_QUANTITY__INGRIDIE;

alter table RECIPE_INGRIDIENT
   drop constraint FK_RECIPE_I_RECIPE_IN_RECIPE;

alter table RELATIONSHIP_23
   drop constraint FK_RELATION_CONTAINS7_TRAINING;

alter table RELATIONSHIP_23
   drop constraint FK_RELATION_IS_A_PART_TRAINING;

alter table TRAINING_PLAN_APPOINTMENT
   drop constraint FK_TRAINING_CONTAINS_TRAINING;

alter table TRAINING_PLAN_APPOINTMENT
   drop constraint FK_TRAINING_IS_REGIST_APPOINTM;

alter table "USER"
   drop constraint FK_USER_IS_FROM_AIM;

alter table "USER"
   drop constraint FK_USER_OWNS_FITNESSL;

alter table "USER"
   drop constraint FK_USER_USER_EMPL_EMPLOYEE;

alter table USER_RECIPE
   drop constraint FK_USER_REC_CALLS_ON_RECIPE;

alter table USER_RECIPE
   drop constraint FK_USER_REC_IS_CALLED_USER;

alter table USER_SPORT
   drop constraint FK_USER_SPO_IS_PRACTI_USER;

alter table USER_SPORT
   drop constraint FK_USER_SPO_PRACTISES_SPORT;

alter table USER_TRAINING_PLAN
   drop constraint FK_USER_TRA_CALLS_ON2_TRAINING;

alter table USER_TRAINING_PLAN
   drop constraint FK_USER_TRA_IS_CALLED_USER;

drop index HAT_FK;

drop table AIM cascade constraints;

drop index APPOINTMENT_EMPLOYEE_FK;

drop index USER_APPOINTMENT_FK;

drop table APPOINTMENT cascade constraints;

drop table AUTHORIZATION cascade constraints;

drop table CATEGORY cascade constraints;

drop index EMPLOYEE_AUTHORIZATION_FK;

drop table EMPLOYEE cascade constraints;

drop index MANAGES_FK;

drop index IS_MANAGED_BY_FK;

drop table EMPLOYEE_RECIPE cascade constraints;

drop index CREATED_FK;

drop index IS_CREATED_BY_FK;

drop table EMPLOYEE_SPORT cascade constraints;

drop index MANAGES2_FK;

drop index IS_MANAGED_BY2_FK;

drop table EMPLOYEE_TRAINING_PLAN cascade constraints;

drop index EXERCISE_TRAINING_TYPE_FK;

drop table EXERCISE cascade constraints;

drop index BELONGS_TO_FK;

drop index CONTAINS5_FK;

drop table EXERCISE_CATEGORY cascade constraints;

drop index CONTAINS3_FK;

drop index IS_PART_OF_FK;

drop table EXERCISE_SPORT cascade constraints;

drop index CONTAINS6_FK;

drop index IS_A_PART_OF2_FK;

drop table EXERCISE_UNIT cascade constraints;

drop index HAS_FK;

drop table FITNESSLEVEL cascade constraints;

drop index BELONGS_FK;

drop table INGRIDIENT cascade constraints;

drop index HAS2_FK;

drop table QUANTITYPRICE cascade constraints;

drop index RECIPE_CATEGORY_FK;

drop index USER_RECIPE_CREATION_FK;

drop table RECIPE cascade constraints;

drop table RECIPECATEGORY cascade constraints;

drop index IS_IN_FK;

drop index CONTAINS4_FK;

drop table RECIPE_APPOINTMENT cascade constraints;

drop index QUANTITY_INGRIDIENT_FK;

drop index RECIPE_INGRIDIENT_QUANTITY_FK;

drop table RECIPE_INGRIDIENT cascade constraints;

drop index CONTAINS5_FK2;

drop index IS_A_PART_OF_FK;

drop table RELATIONSHIP_23 cascade constraints;

drop table SPORT cascade constraints;

drop table TRAINING_PLAN cascade constraints;

drop index IS_REGISTERED_IN_FK;

drop index CONTAINS_FK;

drop table TRAINING_PLAN_APPOINTMENT cascade constraints;

drop table TRAINING_TYPE cascade constraints;

drop table TRAINING_UNIT cascade constraints;

drop index IS_FROM_FK;

drop index USER_EMPLOYEE_FK;

drop index OWNS_FK;

drop table "USER" cascade constraints;

drop index CALLS_ON_FK;

drop index IS_CALLED_BY_FK;

drop table USER_RECIPE cascade constraints;

drop index PRACTISES_FK;

drop index IS_PRACTICED_BY_FK;

drop table USER_SPORT cascade constraints;

drop index CALLS_ON2_FK;

drop index IS_CALLED_BY2_FK;

drop table USER_TRAINING_PLAN cascade constraints;

/*==============================================================*/
/* Table: AIM                                                   */
/*==============================================================*/
create table AIM (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   USE_ID               NUMBER(6)             not null,
   TARGET_DESCRIPTION   VARCHAR2(1024)        not null,
   TARGET_WEIGHT        NUMBER(5,2),
   constraint PK_AIM primary key (ID)
);

comment on table AIM is
'Documents the user’s aim they want to achieve, can be formulated freely and as target weight.

Attributs:
@target description: The user can freely formulate the individual target they want to reach
@target weight: The body weight the user wants to reach in kg

Relations:
One target can be owend by one user';

/*==============================================================*/
/* Index: HAT_FK                                                */
/*==============================================================*/
create index HAT_FK on AIM (
   USE_ID ASC
);

/*==============================================================*/
/* Table: APPOINTMENT                                           */
/*==============================================================*/
create table APPOINTMENT (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   EMP_ID               NUMBER(6),
   USE_ID               NUMBER(6)             not null,
   "DATE"               DATE                  not null,
   constraint PK_APPOINTMENT primary key (ID)
);

comment on table APPOINTMENT is
'Appointments can manage training programs or recipes for users or employees. 

APPOINTMENTs can contain multiple TRAINING PROGRAMs or RECIPEs.
APPOINTMENTs must be owned by an USER.
APPOINTMENTs can be edited by an EMPLOYEE.
 
@date : describes the date of an appointment ';

/*==============================================================*/
/* Index: USER_APPOINTMENT_FK                                   */
/*==============================================================*/
create index USER_APPOINTMENT_FK on APPOINTMENT (
   USE_ID ASC
);

/*==============================================================*/
/* Index: APPOINTMENT_EMPLOYEE_FK                               */
/*==============================================================*/
create index APPOINTMENT_EMPLOYEE_FK on APPOINTMENT (
   EMP_ID ASC
);

/*==============================================================*/
/* Table: AUTHORIZATION                                         */
/*==============================================================*/
create table AUTHORIZATION (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   DEGREE_OF_AUTHORIZATION VARCHAR2(50)          not null,
   DESCRIPTION          VARCHAR2(150)         not null,
   constraint PK_AUTHORIZATION primary key (ID)
);

comment on table AUTHORIZATION is
'Authorizations can be used by employees. 
Defines the general information about an authorisation, e.g. the level of authorization, as well as its description of the authorization level. 

An authorization can be owned by multiple employees. 

@degree of authorization: the Level of authorization 
@description : the description of an authorization ';

/*==============================================================*/
/* Table: CATEGORY                                              */
/*==============================================================*/
create table CATEGORY (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   NAME                 INTEGER               not null,
   constraint PK_CATEGORY primary key (ID)
);

comment on table CATEGORY is
'The category of an exercise. Possibile categorys are strength training, endurance training, speed training, mobility training or coordination training.

A category can belong to one or more exercises.

Attributes:
@name: the name of the category';

/*==============================================================*/
/* Table: EMPLOYEE                                              */
/*==============================================================*/
create table EMPLOYEE (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   AUT_ID               NUMBER(6)             not null,
   NAME                 VARCHAR2(50)          not null,
   FIRST_NAME           VARCHAR2(50)          not null,
   constraint PK_EMPLOYEE primary key (ID)
);

comment on table EMPLOYEE is
'Employees can manage e.g. user, appointments, recipes. 
Defines the general information about an employee, e.g. the surname and first name of the employee. 

An EMPLOYEE has an authorisation. 
An EMPLOYEE can manage, e.g. multiple APPOINTMENTs, multiple USERs, multiple TYPE OF SPORTs, multiple RECIPEs and multiple TRAINING PROGRAMs. 

@name: The last name of the employee
@first name: The first name of the employee
';

/*==============================================================*/
/* Index: EMPLOYEE_AUTHORIZATION_FK                             */
/*==============================================================*/
create index EMPLOYEE_AUTHORIZATION_FK on EMPLOYEE (
   AUT_ID ASC
);

/*==============================================================*/
/* Table: EMPLOYEE_RECIPE                                       */
/*==============================================================*/
create table EMPLOYEE_RECIPE (
   ID                   NUMBER(6)             not null,
   REC_ID               NUMBER(6)             not null,
   constraint PK_EMPLOYEE_RECIPE primary key (ID, REC_ID)
);

/*==============================================================*/
/* Index: IS_MANAGED_BY_FK                                      */
/*==============================================================*/
create index IS_MANAGED_BY_FK on EMPLOYEE_RECIPE (
   ID ASC
);

/*==============================================================*/
/* Index: MANAGES_FK                                            */
/*==============================================================*/
create index MANAGES_FK on EMPLOYEE_RECIPE (
   REC_ID ASC
);

/*==============================================================*/
/* Table: EMPLOYEE_SPORT                                        */
/*==============================================================*/
create table EMPLOYEE_SPORT (
   EMP_ID               NUMBER(6)             not null,
   ID                   NUMBER(6)             not null,
   constraint PK_EMPLOYEE_SPORT primary key (EMP_ID, ID)
);

/*==============================================================*/
/* Index: IS_CREATED_BY_FK                                      */
/*==============================================================*/
create index IS_CREATED_BY_FK on EMPLOYEE_SPORT (
   EMP_ID ASC
);

/*==============================================================*/
/* Index: CREATED_FK                                            */
/*==============================================================*/
create index CREATED_FK on EMPLOYEE_SPORT (
   ID ASC
);

/*==============================================================*/
/* Table: EMPLOYEE_TRAINING_PLAN                                */
/*==============================================================*/
create table EMPLOYEE_TRAINING_PLAN (
   ID                   NUMBER(6)             not null,
   TRA_ID               NUMBER(6)             not null,
   constraint PK_EMPLOYEE_TRAINING_PLAN primary key (ID, TRA_ID)
);

/*==============================================================*/
/* Index: IS_MANAGED_BY2_FK                                     */
/*==============================================================*/
create index IS_MANAGED_BY2_FK on EMPLOYEE_TRAINING_PLAN (
   ID ASC
);

/*==============================================================*/
/* Index: MANAGES2_FK                                           */
/*==============================================================*/
create index MANAGES2_FK on EMPLOYEE_TRAINING_PLAN (
   TRA_ID ASC
);

/*==============================================================*/
/* Table: EXERCISE                                              */
/*==============================================================*/
create table EXERCISE (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   TRA_ID               NUMBER(6)             not null,
   NAME                 VARCHAR2(50)          not null,
   DESCRIPTION          VARCHAR2(1024)        not null,
   DURATION             VARCHAR2(10),
   constraint PK_EXERCISE primary key (ID)
);

comment on table EXERCISE is
'Every exercise must belong to one or more categorys.
Every exercise must belong to one training type.
Every exercise must be part of one or more sports.
Every exercise may be contained in one or more training plans.

Attributes:
@name: name of the exercise
@descripion: the description includes notes on safety and correct execution
@duration: the duration of one repetition of the set. The whole duration is determined programatically and is depending on the repetition and sets';

/*==============================================================*/
/* Index: EXERCISE_TRAINING_TYPE_FK                             */
/*==============================================================*/
create index EXERCISE_TRAINING_TYPE_FK on EXERCISE (
   TRA_ID ASC
);

/*==============================================================*/
/* Table: EXERCISE_CATEGORY                                     */
/*==============================================================*/
create table EXERCISE_CATEGORY (
   EXE_ID               NUMBER(6)             not null,
   ID                   NUMBER(6)             not null,
   constraint PK_EXERCISE_CATEGORY primary key (EXE_ID, ID)
);

/*==============================================================*/
/* Index: CONTAINS5_FK                                          */
/*==============================================================*/
create index CONTAINS5_FK on EXERCISE_CATEGORY (
   EXE_ID ASC
);

/*==============================================================*/
/* Index: BELONGS_TO_FK                                         */
/*==============================================================*/
create index BELONGS_TO_FK on EXERCISE_CATEGORY (
   ID ASC
);

/*==============================================================*/
/* Table: EXERCISE_SPORT                                        */
/*==============================================================*/
create table EXERCISE_SPORT (
   SPO_ID               NUMBER(6)             not null,
   ID                   NUMBER(6)             not null,
   constraint PK_EXERCISE_SPORT primary key (SPO_ID, ID)
);

/*==============================================================*/
/* Index: IS_PART_OF_FK                                         */
/*==============================================================*/
create index IS_PART_OF_FK on EXERCISE_SPORT (
   SPO_ID ASC
);

/*==============================================================*/
/* Index: CONTAINS3_FK                                          */
/*==============================================================*/
create index CONTAINS3_FK on EXERCISE_SPORT (
   ID ASC
);

/*==============================================================*/
/* Table: EXERCISE_UNIT                                         */
/*==============================================================*/
create table EXERCISE_UNIT (
   TRA_ID               NUMBER(6)             not null,
   ID                   NUMBER(6)             not null,
   REPETITIONS          NUMBER                not null,
   SETS                 NUMBER                not null,
   constraint PK_EXERCISE_UNIT primary key (TRA_ID, ID)
);

/*==============================================================*/
/* Index: IS_A_PART_OF2_FK                                      */
/*==============================================================*/
create index IS_A_PART_OF2_FK on EXERCISE_UNIT (
   TRA_ID ASC
);

/*==============================================================*/
/* Index: CONTAINS6_FK                                          */
/*==============================================================*/
create index CONTAINS6_FK on EXERCISE_UNIT (
   ID ASC
);

/*==============================================================*/
/* Table: FITNESSLEVEL                                          */
/*==============================================================*/
create table FITNESSLEVEL (
   USE_ID               NUMBER(6)             not null,
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   STATUS               VARCHAR2(25)          not null,
   constraint PK_FITNESSLEVEL primary key (USE_ID, ID)
);

comment on table FITNESSLEVEL is
'Includes previous experience, current endurance, strength, agility and speed performance and combines these values ??into a level.

Attribut:
@status: the users can freely formulate their fitness level

Relation:
every status ist owned by a user';

/*==============================================================*/
/* Index: HAS_FK                                                */
/*==============================================================*/
create index HAS_FK on FITNESSLEVEL (
   USE_ID ASC
);

/*==============================================================*/
/* Table: INGRIDIENT                                            */
/*==============================================================*/
create table INGRIDIENT (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   QUA_ID               NUMBER(6)             not null,
   NAME                 VARCHAR2(50)          not null,
   FOODCATEGORY         INTEGER               not null,
   ENERGY               NUMBER(6,1)           not null,
   PROTEINCONTENT       NUMBER(3,1),
   FATCONTENT           NUMBER(3,1),
   ROUGHAGECONTENT      NUMBER(3,1),
   WATERCONTENT         NUMBER(3,1),
   constraint PK_INGRIDIENT primary key (ID)
);

comment on table INGRIDIENT is
'Ingridient making up recipes.
Defines the general information about an ingridient, e.g. Name, as well as its nutrional values.
Additionaly it defines a rough price estimate of said ingredient.

An INGRIDIENT can be part of a multiple RECIPE_INGRIDIENTs .
Each INGRIDIENT has a price range (QUANTITYPRICE).

@name : The name of the ingridient
@foodcategory: The type of ingridient (meat, vegetarian, vegan) (internally mapped to enum)
@energy: Caloric content of the ingridient (ccal)
@proteincontent: Protein content of the ingridient (gram)
@fatcontent: Fat content of the ingridient (gram)
@roughagecontent: Roughage content of the ingridient (gram)
@watercontent: The water content of the ingridient (gram)';

/*==============================================================*/
/* Index: BELONGS_FK                                            */
/*==============================================================*/
create index BELONGS_FK on INGRIDIENT (
   QUA_ID ASC
);

/*==============================================================*/
/* Table: QUANTITYPRICE                                         */
/*==============================================================*/
create table QUANTITYPRICE (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   ING_ID               NUMBER(6),
   QUANTITY_UNIT        INTEGER               not null,
   QUANTITY             NUMBER                not null,
   PRICE_LOWER          NUMBER(4,2)           not null,
   PRICE_UPPER          NUMBER(4,2)           not null,
   constraint PK_QUANTITYPRICE primary key (ID)
);

comment on table QUANTITYPRICE is
'Price range for specific quantity.
Gives a price range for a specific quantity in different units, such as weights and counts.

Used by ingridients.

@quantity unit : The unit in which the quantity is measured (gramms, pounds, pieces, table spoons, tea spoons, cups) (internally mapped to enum)
@quantity: The acutal quantity specified by the unit
@price lower: The lower price of the quantity
@price upper: The upper price of the quantity';

/*==============================================================*/
/* Index: HAS2_FK                                               */
/*==============================================================*/
create index HAS2_FK on QUANTITYPRICE (
   ING_ID ASC
);

/*==============================================================*/
/* Table: RECIPE                                                */
/*==============================================================*/
create table RECIPE (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   REC_ID               NUMBER(6)             not null,
   USE_ID               NUMBER(6),
   NAME                 VARCHAR2(256)         not null,
   DESCRIPTION          VARCHAR2(1024)        not null,
   INSTRUCTIONS         CLOB                  not null,
   VISIBILITY           INTEGER               not null,
   constraint PK_RECIPE primary key (ID)
);

comment on table RECIPE is
'Recipe for a meal.
Unites all components of a food recipe into one, containing quantified ingridients, a description of the meal and instructions of how to make the meal.
Recipes contain a lot of extra information for filtering and sorting, such as type of food and rough price.

A RECIPE has multiple RECIPE_INGRIDIENTS and is part of a RECIPECATEGORY.
RECIPEs are created by user and accessed by them, while being managed by EMPLOYEs.
RECIPEs can be part of multiple appointments.

@name: The name of the meal
@description: A rough overview of what this meal is.
@instructions: The instructions for how to cook the meal.
@visibility: The visibility of this recipe (private, public)';

/*==============================================================*/
/* Index: USER_RECIPE_CREATION_FK                               */
/*==============================================================*/
create index USER_RECIPE_CREATION_FK on RECIPE (
   USE_ID ASC
);

/*==============================================================*/
/* Index: RECIPE_CATEGORY_FK                                    */
/*==============================================================*/
create index RECIPE_CATEGORY_FK on RECIPE (
   REC_ID ASC
);

/*==============================================================*/
/* Table: RECIPECATEGORY                                        */
/*==============================================================*/
create table RECIPECATEGORY (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   NAME                 VARCHAR2(128)         not null,
   FOODCATEGORY         INTEGER               not null,
   constraint PK_RECIPECATEGORY primary key (ID)
);

comment on table RECIPECATEGORY is
'Category of recipes.
Is meant for easy lookup of different kinds of food, such as breakfast, supper, dinner, snacks, weight gaining, weight loosing, etc.

One RECIPECATEGORY contains multiple recipes.

@name : The name of the category
@foodcategory : The type of ingridient (meat, vegetarian, vegan) (internally mapped to enum)';

/*==============================================================*/
/* Table: RECIPE_APPOINTMENT                                    */
/*==============================================================*/
create table RECIPE_APPOINTMENT (
   ID                   NUMBER(6)             not null,
   APP_ID               NUMBER(6)             not null,
   constraint PK_RECIPE_APPOINTMENT primary key (ID, APP_ID)
);

/*==============================================================*/
/* Index: CONTAINS4_FK                                          */
/*==============================================================*/
create index CONTAINS4_FK on RECIPE_APPOINTMENT (
   ID ASC
);

/*==============================================================*/
/* Index: IS_IN_FK                                              */
/*==============================================================*/
create index IS_IN_FK on RECIPE_APPOINTMENT (
   APP_ID ASC
);

/*==============================================================*/
/* Table: RECIPE_INGRIDIENT                                     */
/*==============================================================*/
create table RECIPE_INGRIDIENT (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   REC_ID               NUMBER(6)             not null,
   ING_ID               NUMBER(6)             not null,
   QUANTITY             NUMBER                not null,
   constraint PK_RECIPE_INGRIDIENT primary key (ID)
);

comment on table RECIPE_INGRIDIENT is
'Counted mapping for ingridient
Mapps an ingridient to a recipe, while giving it an actual quantity as needed for the recipe.
The unit of quantiy is derived from the quantity unit connected to the ingridient

One INGRIDIENT maps to multiple RECIPEINGRIDIENT maps to one RECIPE and the other way around.

@quanity: The quantity of the ingridient used';

/*==============================================================*/
/* Index: RECIPE_INGRIDIENT_QUANTITY_FK                         */
/*==============================================================*/
create index RECIPE_INGRIDIENT_QUANTITY_FK on RECIPE_INGRIDIENT (
   REC_ID ASC
);

/*==============================================================*/
/* Index: QUANTITY_INGRIDIENT_FK                                */
/*==============================================================*/
create index QUANTITY_INGRIDIENT_FK on RECIPE_INGRIDIENT (
   ING_ID ASC
);

/*==============================================================*/
/* Table: RELATIONSHIP_23                                       */
/*==============================================================*/
create table RELATIONSHIP_23 (
   TRA_ID               NUMBER(6)             not null,
   ID                   NUMBER(6)             not null,
   constraint PK_RELATIONSHIP_23 primary key (TRA_ID, ID)
);

/*==============================================================*/
/* Index: IS_A_PART_OF_FK                                       */
/*==============================================================*/
create index IS_A_PART_OF_FK on RELATIONSHIP_23 (
   TRA_ID ASC
);

/*==============================================================*/
/* Index: CONTAINS5_FK2                                         */
/*==============================================================*/
create index CONTAINS5_FK2 on RELATIONSHIP_23 (
   ID ASC
);

/*==============================================================*/
/* Table: SPORT                                                 */
/*==============================================================*/
create table SPORT (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   NAME                 VARCHAR2(50)          not null,
   DESCRIPTION          VARCHAR2(1024)        not null,
   constraint PK_SPORT primary key (ID)
);

comment on table SPORT is
'Defines the kind of sport and includes the generall information in the description.

A sport can be practised by multiple users.
A sport can include several exercises.
A sport can be created or edited by an employee.

Attributes:
@name: the name of the sport
@description: a description of the sport which may contains e.g. necessary material and rules';

/*==============================================================*/
/* Table: TRAINING_PLAN                                         */
/*==============================================================*/
create table TRAINING_PLAN (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   NAME                 VARCHAR2(100)         not null,
   DESCRIPTION          VARCHAR2(1024)        not null,
   DIFFICULTY           VARCHAR2(50)          not null,
   constraint PK_TRAINING_PLAN primary key (ID)
);

comment on table TRAINING_PLAN is
'A plan with multiple exercises to train a certain sport or category.

A training plan can be called up by a user.
A training plan can be registered in one appointment..
A training plan must contain one ore more exercises.
A training plan ca be managed by an employee.

Attributes:
@name: name of the plan
@description: the description may contains informations e.g. sport type, category or necessary fitnesslevel of the user';

/*==============================================================*/
/* Table: TRAINING_PLAN_APPOINTMENT                             */
/*==============================================================*/
create table TRAINING_PLAN_APPOINTMENT (
   ID                   NUMBER(6)             not null,
   APP_ID               NUMBER(6)             not null,
   constraint PK_TRAINING_PLAN_APPOINTMENT primary key (ID, APP_ID)
);

/*==============================================================*/
/* Index: CONTAINS_FK                                           */
/*==============================================================*/
create index CONTAINS_FK on TRAINING_PLAN_APPOINTMENT (
   ID ASC
);

/*==============================================================*/
/* Index: IS_REGISTERED_IN_FK                                   */
/*==============================================================*/
create index IS_REGISTERED_IN_FK on TRAINING_PLAN_APPOINTMENT (
   APP_ID ASC
);

/*==============================================================*/
/* Table: TRAINING_TYPE                                         */
/*==============================================================*/
create table TRAINING_TYPE (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   NAME                 VARCHAR2(50)          not null,
   constraint PK_TRAINING_TYPE primary key (ID)
);

comment on table TRAINING_TYPE is
'Decribes the type of the training for including the exercise at a mathcing time in the training plan. Possible training types could be e.g. stretching, warm up or cool down.

Each training type may contains one or more exercises.

Attributes:
@name: the name of the type';

/*==============================================================*/
/* Table: TRAINING_UNIT                                         */
/*==============================================================*/
create table TRAINING_UNIT (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   NAME                 VARCHAR2(100),
   DESCRIPTION          VARCHAR2(1024),
   DIFFICULTY           VARCHAR2(50),
   constraint PK_TRAINING_UNIT primary key (ID)
);

/*==============================================================*/
/* Table: "USER"                                                */
/*==============================================================*/
create table "USER" (
   ID                   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   EMP_ID               NUMBER(6),
   AIM_ID               NUMBER(6),
   FIT_ID               NUMBER(6),
   NAME                 VARCHAR2(50)          not null,
   FIRST_NAME           VARCHAR2(50)          not null,
   WEIGHT               NUMBER(6,2),
   HEIGHT               NUMBER(3,2),
   BODY_FAT_PERCENTAGE  NUMBER(3,1),
   BASAL_METABOLIC_RATE NUMBER(7),
   constraint PK_USER primary key (ID)
);

comment on table "USER" is
'Basic information about the user, to identify them and to save values, that enable individually training und nutrition plans.

Attributs:
@name: last name of the user
@first name: first name of the user
@weight: user’s weight in kg, as indicator for training plan and nutrition
@height: user’s height to calculate the body mass index in m
@body fat percentage: user’s bady fat percentage in kg/ m², as indicator for training pan and nutrion
@basal metabolic rate: user’s basal metabolic rate in cal/hour, as indicator for training pan and nutrion

Relations:
every user can practice various sports.
every user can have an aim
every user can have a fitness level
every user can be supervised by an employee (depending on the package they booked)
every user can access all recipies
every user can create recipies
every user can access their appointments';

/*==============================================================*/
/* Index: OWNS_FK                                               */
/*==============================================================*/
create index OWNS_FK on "USER" (
   FIT_ID ASC,
   FIT_ID ASC
);

/*==============================================================*/
/* Index: USER_EMPLOYEE_FK                                      */
/*==============================================================*/
create index USER_EMPLOYEE_FK on "USER" (
   EMP_ID ASC
);

/*==============================================================*/
/* Index: IS_FROM_FK                                            */
/*==============================================================*/
create index IS_FROM_FK on "USER" (
   AIM_ID ASC
);

/*==============================================================*/
/* Table: USER_RECIPE                                           */
/*==============================================================*/
create table USER_RECIPE (
   USE_ID               NUMBER(6)             not null,
   ID                   NUMBER(6)             not null,
   constraint PK_USER_RECIPE primary key (USE_ID, ID)
);

/*==============================================================*/
/* Index: IS_CALLED_BY_FK                                       */
/*==============================================================*/
create index IS_CALLED_BY_FK on USER_RECIPE (
   USE_ID ASC
);

/*==============================================================*/
/* Index: CALLS_ON_FK                                           */
/*==============================================================*/
create index CALLS_ON_FK on USER_RECIPE (
   ID ASC
);

/*==============================================================*/
/* Table: USER_SPORT                                            */
/*==============================================================*/
create table USER_SPORT (
   ID                   NUMBER(6)             not null,
   SPO_ID               NUMBER(6)             not null,
   constraint PK_USER_SPORT primary key (ID, SPO_ID)
);

/*==============================================================*/
/* Index: IS_PRACTICED_BY_FK                                    */
/*==============================================================*/
create index IS_PRACTICED_BY_FK on USER_SPORT (
   ID ASC
);

/*==============================================================*/
/* Index: PRACTISES_FK                                          */
/*==============================================================*/
create index PRACTISES_FK on USER_SPORT (
   SPO_ID ASC
);

/*==============================================================*/
/* Table: USER_TRAINING_PLAN                                    */
/*==============================================================*/
create table USER_TRAINING_PLAN (
   USE_ID               NUMBER(6)             not null,
   ID                   NUMBER(6)             not null,
   constraint PK_USER_TRAINING_PLAN primary key (USE_ID, ID)
);

/*==============================================================*/
/* Index: IS_CALLED_BY2_FK                                      */
/*==============================================================*/
create index IS_CALLED_BY2_FK on USER_TRAINING_PLAN (
   USE_ID ASC
);

/*==============================================================*/
/* Index: CALLS_ON2_FK                                          */
/*==============================================================*/
create index CALLS_ON2_FK on USER_TRAINING_PLAN (
   ID ASC
);

alter table AIM
   add constraint FK_AIM_HAT_USER foreign key (USE_ID)
      references "USER" (ID);

alter table APPOINTMENT
   add constraint FK_APPOINTM_APPOINTME_EMPLOYEE foreign key (EMP_ID)
      references EMPLOYEE (ID);

alter table APPOINTMENT
   add constraint FK_APPOINTM_USER_APPO_USER foreign key (USE_ID)
      references "USER" (ID);

alter table EMPLOYEE
   add constraint FK_EMPLOYEE_EMPLOYEE__AUTHORIZ foreign key (AUT_ID)
      references AUTHORIZATION (ID);

alter table EMPLOYEE_RECIPE
   add constraint FK_EMPLOYEE_IS_MANAGE_EMPLOYEE foreign key (ID)
      references EMPLOYEE (ID);

alter table EMPLOYEE_RECIPE
   add constraint FK_EMPLOYEE_MANAGES_RECIPE foreign key (REC_ID)
      references RECIPE (ID);

alter table EMPLOYEE_SPORT
   add constraint FK_EMPLOYEE_CREATED_SPORT foreign key (ID)
      references SPORT (ID);

alter table EMPLOYEE_SPORT
   add constraint FK_EMPLOYEE_IS_CREATE_EMPLOYEE foreign key (EMP_ID)
      references EMPLOYEE (ID);

alter table EMPLOYEE_TRAINING_PLAN
   add constraint FK_EMPLOYEE_IS_MANAGE_EMPLOYEE foreign key (ID)
      references EMPLOYEE (ID);

alter table EMPLOYEE_TRAINING_PLAN
   add constraint FK_EMPLOYEE_MANAGES2_TRAINING foreign key (TRA_ID)
      references TRAINING_PLAN (ID);

alter table EXERCISE
   add constraint FK_EXERCISE_EXERCISE__TRAINING foreign key (TRA_ID)
      references TRAINING_TYPE (ID);

alter table EXERCISE_CATEGORY
   add constraint FK_EXERCISE_BELONGS_T_CATEGORY foreign key (ID)
      references CATEGORY (ID);

alter table EXERCISE_CATEGORY
   add constraint FK_EXERCISE_CONTAINS5_EXERCISE foreign key (EXE_ID)
      references EXERCISE (ID);

alter table EXERCISE_SPORT
   add constraint FK_EXERCISE_CONTAINS3_EXERCISE foreign key (ID)
      references EXERCISE (ID);

alter table EXERCISE_SPORT
   add constraint FK_EXERCISE_IS_PART_O_SPORT foreign key (SPO_ID)
      references SPORT (ID);

alter table EXERCISE_UNIT
   add constraint FK_EXERCISE_CONTAINS6_EXERCISE foreign key (ID)
      references EXERCISE (ID);

alter table EXERCISE_UNIT
   add constraint FK_EXERCISE_IS_A_PART_TRAINING foreign key (TRA_ID)
      references TRAINING_UNIT (ID);

alter table FITNESSLEVEL
   add constraint FK_FITNESSL_HAS_USER foreign key (USE_ID)
      references "USER" (ID);

alter table INGRIDIENT
   add constraint FK_INGRIDIE_BELONGS_QUANTITY foreign key (QUA_ID)
      references QUANTITYPRICE (ID);

alter table QUANTITYPRICE
   add constraint FK_QUANTITY_HAS2_INGRIDIE foreign key (ING_ID)
      references INGRIDIENT (ID);

alter table RECIPE
   add constraint FK_RECIPE_RECIPE_CA_RECIPECA foreign key (REC_ID)
      references RECIPECATEGORY (ID);

alter table RECIPE
   add constraint FK_RECIPE_USER_RECI_USER foreign key (USE_ID)
      references "USER" (ID);

alter table RECIPE_APPOINTMENT
   add constraint FK_RECIPE_A_CONTAINS4_RECIPE foreign key (ID)
      references RECIPE (ID);

alter table RECIPE_APPOINTMENT
   add constraint FK_RECIPE_A_IS_IN_APPOINTM foreign key (APP_ID)
      references APPOINTMENT (ID);

alter table RECIPE_INGRIDIENT
   add constraint FK_RECIPE_I_QUANTITY__INGRIDIE foreign key (ING_ID)
      references INGRIDIENT (ID);

alter table RECIPE_INGRIDIENT
   add constraint FK_RECIPE_I_RECIPE_IN_RECIPE foreign key (REC_ID)
      references RECIPE (ID);

alter table RELATIONSHIP_23
   add constraint FK_RELATION_CONTAINS7_TRAINING foreign key (ID)
      references TRAINING_UNIT (ID);

alter table RELATIONSHIP_23
   add constraint FK_RELATION_IS_A_PART_TRAINING foreign key (TRA_ID)
      references TRAINING_PLAN (ID);

alter table TRAINING_PLAN_APPOINTMENT
   add constraint FK_TRAINING_CONTAINS_TRAINING foreign key (ID)
      references TRAINING_PLAN (ID);

alter table TRAINING_PLAN_APPOINTMENT
   add constraint FK_TRAINING_IS_REGIST_APPOINTM foreign key (APP_ID)
      references APPOINTMENT (ID);

alter table "USER"
   add constraint FK_USER_IS_FROM_AIM foreign key (AIM_ID)
      references AIM (ID);

alter table "USER"
   add constraint FK_USER_OWNS_FITNESSL foreign key (FIT_ID, FIT_ID)
      references FITNESSLEVEL (USE_ID, ID);

alter table "USER"
   add constraint FK_USER_USER_EMPL_EMPLOYEE foreign key (EMP_ID)
      references EMPLOYEE (ID);

alter table USER_RECIPE
   add constraint FK_USER_REC_CALLS_ON_RECIPE foreign key (ID)
      references RECIPE (ID);

alter table USER_RECIPE
   add constraint FK_USER_REC_IS_CALLED_USER foreign key (USE_ID)
      references "USER" (ID);

alter table USER_SPORT
   add constraint FK_USER_SPO_IS_PRACTI_USER foreign key (ID)
      references "USER" (ID);

alter table USER_SPORT
   add constraint FK_USER_SPO_PRACTISES_SPORT foreign key (SPO_ID)
      references SPORT (ID);

alter table USER_TRAINING_PLAN
   add constraint FK_USER_TRA_CALLS_ON2_TRAINING foreign key (ID)
      references TRAINING_PLAN (ID);

alter table USER_TRAINING_PLAN
   add constraint FK_USER_TRA_IS_CALLED_USER foreign key (USE_ID)
      references "USER" (ID);

