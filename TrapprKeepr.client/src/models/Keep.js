export class Keep {
    constructor(data) {
        this.id = data.id
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.views = data.views || 0
        this.kept = data.kept || 0
        this.creatorId = data.creatorId
        this.creator = data.creator || {}
        this.createdAt = new Date(data.createdAt)
        this.updatedAt = new Date(data.updatedAt)
    }
}