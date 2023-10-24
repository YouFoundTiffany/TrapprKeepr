import { Profile } from "./Account.js"

Profile

export class VaultKeep {
    constructor(data) {
        this.id = data.id
        this.vaultId = data.vaultId
        this.keepId = data.keepId
        this.creatorId = data.creatorId
        // NOTE maybe too much? not sure...but gonna try it and can take off if needed.
        this.profile = data.profile
    }
}