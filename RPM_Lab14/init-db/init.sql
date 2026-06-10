CREATE TABLE "Contacts" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL,
    "Phone" VARCHAR(20) NOT NULL
);

INSERT INTO "Contacts" ("Name", "Phone") VALUES
('Иванов Иван', '+79991234567'),
('Петрова Мария', '+79997654321'),
('Сидоров Алексей', '+79995558899');
