import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
class VaultsService {
    // STUB Create Vault
    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        logger.log('[CREATED VAULT]', res.data)
        const newVault = new Vault(res.data)
        AppState.vaults.push(new Vault(res.data))
        return newVault
    }

    // STUB getVaults
    async getVaults() {

        const res = await api.get('api/vaults')
        logger.log('[GOT ALL VAULTS]', res.data)
        // const vaults = AppState.vaults = res.data.map(vault => new Vault(vaults))
        // AppState.vaults = vaults
        const vaults = res.data.map(vault => new Vault(vault))
        AppState.vaults = vaults;

    }

    // STUB getVaultsByProfile
    async getVaultsByProfile(profileId) {
        const response = await api.get(`api/profiles/${profileId}/vaults`)
        logger.log('[MY VAULTS]', response.data)
        const myVaults = AppState.vaults = response.data.map(v => new Vault(v))
        AppState.vaults = myVaults;
    }
    async getVaultDetails(vaultId) {
        const res = await api.get('api' + '/' + 'vaults' + '/' + `${vaultId}`)
        logger.log('[GOT VAULT BY ID ]', res.data)

        AppState.activeVault = new Vault(res.data)
    }
}
export const vaultsService = new VaultsService()