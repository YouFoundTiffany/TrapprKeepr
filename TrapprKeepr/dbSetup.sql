CREATE TABLE
    IF NOT EXISTS Accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
        coverImg varchar(255) COMMENT 'Cover Image'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS vaults(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(255) NOT NULL,
        description VARCHAR(255) NOT NULL,
        category ENUM(
            'misc',
            'unicorns',
            'dragons',
            'gryphons',
            'mermaids',
            'faeries',
            'fluffies'
        ) DEFAULT 'misc',
        img VARCHAR(700) NOT NULL,
        isPrivate BOOLEAN DEFAULT FALSE,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL,
        creator VARCHAR(255) NOT NULL,
        FOREIGN KEY(creatorId) REFERENCES Accounts(id) ON DELETE CASCADE,
        FOREIGN KEY(creator) REFERENCES Accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS keeps(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(500) NOT NULL,
        description VARCHAR(500) NOT NULL,
        img VARCHAR(500) NOT NULL,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL,
        creator VARCHAR(255) NOT NULL,
        FOREIGN KEY(creatorId) REFERENCES Accounts(id) ON DELETE CASCADE,
        FOREIGN KEY(creator) REFERENCES Accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS vaultKeeps(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        vaultId INT NOT NULL,
        keepId INT NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        creator VARCHAR(255) NOT NULL,
        FOREIGN KEY (vaultId) REFERENCES Vaults(id) ON DELETE CASCADE,
        FOREIGN KEY (keepId) REFERENCES Keeps(id) ON DELETE CASCADE,
        FOREIGN KEY (creatorId) REFERENCES Accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (creator) REFERENCES Accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

INSERT INTO
    vaults (
        name,
        description,
        category,
        img,
        creatorId,
    )
VALUES (
        'Cutie',
        'unicorns',
        'unicorns should always have rainbows around them',
        'https://static.vecteezy.com/system/resources/previews/024/507/770/original/cute-unicorns-with-rainbow-hair-ai-generative-png.png',
        '64dcedd3c5d6acdbaa571baa'
    );