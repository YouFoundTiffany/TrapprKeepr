export class Vault {
    constructor(data) {
        this.id = data.id
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.isPrivate = data.isPrivate || false
        this.creatorId = data.creatorId
        this.creator = data.creator
        this.createdAt = data.createdAt
        this.updatedAt = data.updatedAt
        // NOTE classed on the VaultKeeps
        this.isVault = 'this is a classed vault'

    }
}