-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2019-12-18 00:14:20.67

-- foreign keys
ALTER TABLE Additional DROP CONSTRAINT Additionally_Type;

ALTER TABLE Additional_to_meal DROP CONSTRAINT Additionally_to_meal_Additionally;

ALTER TABLE Additional_to_meal DROP CONSTRAINT Additionally_to_meal_Meal;

ALTER TABLE Bill DROP CONSTRAINT Bill_Order;

ALTER TABLE Delivery DROP CONSTRAINT Delivery_Bill;

ALTER TABLE Delivery DROP CONSTRAINT Delivery_Deliveryman;

ALTER TABLE Delivery DROP CONSTRAINT Delivery_Restauran;

ALTER TABLE Delivery DROP CONSTRAINT Delivery_User;

ALTER TABLE Ingredient_to_recipe DROP CONSTRAINT Ingredient_to_receipt_Ingredient;

ALTER TABLE Ingredient_to_recipe DROP CONSTRAINT Ingredient_to_recipe_Meal;

ALTER TABLE Meal DROP CONSTRAINT Meal_Type;

ALTER TABLE meal_to_order DROP CONSTRAINT meal_to_order_Meal;

ALTER TABLE meal_to_order DROP CONSTRAINT meal_to_order_Order;

-- tables
DROP TABLE Additional;

DROP TABLE Additional_to_meal;

DROP TABLE Bill;

DROP TABLE Delivery;

DROP TABLE Deliveryman;

DROP TABLE Ingredient;

DROP TABLE Ingredient_to_recipe;

DROP TABLE Meal;

DROP TABLE "Order";

DROP TABLE Restaurant;

DROP TABLE Type;

DROP TABLE "User";

DROP TABLE meal_to_order;

CREATE TABLE Additional (
    id_additional int  NOT NULL,
    name varchar(30)  NOT NULL,
    price float(4)  NOT NULL,
    Type_id_type int  NOT NULL,
    CONSTRAINT Additional_pk PRIMARY KEY  (id_additional)
);

-- Table: Additional_to_meal
CREATE TABLE Additional_to_meal (
    Meal_id_meal int  NOT NULL,
    Additional_id_additional int  NOT NULL,
    amount int  NOT NULL,
    CONSTRAINT Additional_to_meal_pk PRIMARY KEY  (Meal_id_meal,Additional_id_additional)
);

-- Table: Bill
CREATE TABLE Bill (
    id_bill int  NOT NULL,
    total_cost int  NOT NULL,
    time int  NOT NULL,
    payment_method varchar(20)  NOT NULL,
    Order_id_order int  NOT NULL,
    CONSTRAINT Bill_pk PRIMARY KEY  (id_bill)
);

-- Table: Delivery
CREATE TABLE Delivery (
    id_delivery int  NOT NULL,
    Bill_id_bill int  NOT NULL,
    address varchar(50)  NOT NULL,
    delivery_time datetime  NOT NULL,
    User_id_user int  NOT NULL,
    Restaurant_id_restaurant int  NOT NULL,
    Deliveryman_id_deliveryman int  NOT NULL,
    CONSTRAINT Delivery_pk PRIMARY KEY  (id_delivery)
);

-- Table: Deliveryman
CREATE TABLE Deliveryman (
    id_deliveryman int  NOT NULL,
    name varchar(30)  NOT NULL,
    surname varchar(30)  NOT NULL,
    salary int  NOT NULL,
    home_address varchar(40)  NOT NULL,
    employment_date date  NOT NULL,
    CONSTRAINT Deliveryman_pk PRIMARY KEY  (id_deliveryman)
);

-- Table: Ingredient
CREATE TABLE Ingredient (
    id_Ingredient int  NOT NULL,
    name varchar(60)  NOT NULL,
    vegetarian bit  NULL,
    spicy bit  NULL,
    calories int  NULL,
    CONSTRAINT Ingredient_pk PRIMARY KEY  (id_Ingredient)
);

-- Table: Ingredient_to_recipe
CREATE TABLE Ingredient_to_recipe (
    Ingredient_id_Ingredient int  NOT NULL,
    amount int  NOT NULL,
    Meal_id_meal int  NOT NULL,
    CONSTRAINT Ingredient_to_recipe_pk PRIMARY KEY  (Ingredient_id_Ingredient)
);

-- Table: Meal
CREATE TABLE Meal (
    id_meal int  NOT NULL,
    name varchar(30)  NOT NULL,
    description varchar(100)  NOT NULL,
    price float(6)  NOT NULL,
    Type_id_type int  NOT NULL,
    CONSTRAINT Meal_pk PRIMARY KEY  (id_meal)
);

-- Table: Order
CREATE TABLE "Order" (
    id_order int  NOT NULL,
    cost int  NOT NULL,
    CONSTRAINT Order_pk PRIMARY KEY  (id_order)
);

-- Table: Restaurant
CREATE TABLE Restaurant (
    id_restaurant int  NOT NULL,
    address varchar(50)  NOT NULL,
    size int  NOT NULL,
    CONSTRAINT Restaurant_pk PRIMARY KEY  (id_restaurant)
);

-- Table: Type
CREATE TABLE Type (
    id_type int  NOT NULL,
    name varchar(30)  NOT NULL,
    CONSTRAINT Type_pk PRIMARY KEY  (id_type)
);

-- Table: User
CREATE TABLE "User" (
    id_user int  NOT NULL,
    name varchar(30)  NOT NULL,
    surname varchar(30)  NOT NULL,
    phone_number varchar(11)  NOT NULL,
    CONSTRAINT User_pk PRIMARY KEY  (id_user)
);

-- Table: meal_to_order
CREATE TABLE meal_to_order (
    Order_id_order int  NOT NULL,
    Meal_id_meal int  NOT NULL,
    amount int  NOT NULL,
    CONSTRAINT meal_to_order_pk PRIMARY KEY  (Order_id_order,Meal_id_meal)
);

-- foreign keys
-- Reference: Additionally_Type (table: Additional)
ALTER TABLE Additional ADD CONSTRAINT Additionally_Type
    FOREIGN KEY (Type_id_type)
    REFERENCES Type (id_type);

-- Reference: Additionally_to_meal_Additionally (table: Additional_to_meal)
ALTER TABLE Additional_to_meal ADD CONSTRAINT Additionally_to_meal_Additionally
    FOREIGN KEY (Additional_id_additional)
    REFERENCES Additional (id_additional);

-- Reference: Additionally_to_meal_Meal (table: Additional_to_meal)
ALTER TABLE Additional_to_meal ADD CONSTRAINT Additionally_to_meal_Meal
    FOREIGN KEY (Meal_id_meal)
    REFERENCES Meal (id_meal);

-- Reference: Bill_Order (table: Bill)
ALTER TABLE Bill ADD CONSTRAINT Bill_Order
    FOREIGN KEY (Order_id_order)
    REFERENCES "Order" (id_order);

-- Reference: Delivery_Bill (table: Delivery)
ALTER TABLE Delivery ADD CONSTRAINT Delivery_Bill
    FOREIGN KEY (Bill_id_bill)
    REFERENCES Bill (id_bill);

-- Reference: Delivery_Deliveryman (table: Delivery)
ALTER TABLE Delivery ADD CONSTRAINT Delivery_Deliveryman
    FOREIGN KEY (Deliveryman_id_deliveryman)
    REFERENCES Deliveryman (id_deliveryman);

-- Reference: Delivery_Restauran (table: Delivery)
ALTER TABLE Delivery ADD CONSTRAINT Delivery_Restauran
    FOREIGN KEY (Restaurant_id_restaurant)
    REFERENCES Restaurant (id_restaurant);

-- Reference: Delivery_User (table: Delivery)
ALTER TABLE Delivery ADD CONSTRAINT Delivery_User
    FOREIGN KEY (User_id_user)
    REFERENCES "User" (id_user);

-- Reference: Ingredient_to_receipt_Ingredient (table: Ingredient_to_recipe)
ALTER TABLE Ingredient_to_recipe ADD CONSTRAINT Ingredient_to_receipt_Ingredient
    FOREIGN KEY (Ingredient_id_Ingredient)
    REFERENCES Ingredient (id_Ingredient);

-- Reference: Ingredient_to_recipe_Meal (table: Ingredient_to_recipe)
ALTER TABLE Ingredient_to_recipe ADD CONSTRAINT Ingredient_to_recipe_Meal
    FOREIGN KEY (Meal_id_meal)
    REFERENCES Meal (id_meal);

-- Reference: Meal_Type (table: Meal)
ALTER TABLE Meal ADD CONSTRAINT Meal_Type
    FOREIGN KEY (Type_id_type)
    REFERENCES Type (id_type);

-- Reference: meal_to_order_Meal (table: meal_to_order)
ALTER TABLE meal_to_order ADD CONSTRAINT meal_to_order_Meal
    FOREIGN KEY (Meal_id_meal)
    REFERENCES Meal (id_meal);

-- Reference: meal_to_order_Order (table: meal_to_order)
ALTER TABLE meal_to_order ADD CONSTRAINT meal_to_order_Order
    FOREIGN KEY (Order_id_order)
    REFERENCES "Order" (id_order);

-- End of file.

