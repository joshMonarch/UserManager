CREATE TABLE IF NOT EXISTS "Roles" (
    "id" SERIAL PRIMARY KEY,
    "name" TEXT NOT NULL UNIQUE
);
INSERT INTO "Roles" ("name")
VALUES ('Admin'),
    ('User'),
    ('Guest');
CREATE TABLE IF NOT EXISTS "Users" (
    "id" SERIAL PRIMARY KEY,
    "fullname" TEXT NOT NULL,
    "age" INT NOT NULL,
    "email" TEXT NOT NULL UNIQUE,
    "password" TEXT NOT NULL,
    "role" SERIAL REFERENCES "Roles"("id") NOT NULL,
    "created_at" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    "updated_at" TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
INSERT INTO "Users" ("fullname", "age", "email", "password", "role")
VALUES ('admin', 30, 'admin@example.com', 'admin123', 1);