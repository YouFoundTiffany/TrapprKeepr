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
    }
}