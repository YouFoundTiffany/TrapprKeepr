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
        logger.log('[go vaults]', res.data)
        // const vaults = AppState.vaults = res.data.map(vault => new Vault(vaults))
        // AppState.vaults = vaults
        const vaults = res.data.map(vault => new Vault(vault))
        AppState.vaults = vaults;

    }

    // STUB getVaultsByProfile
    async getVaultsByProfile() {
        logger.log(AppState.account.id)
        let res = await api.get(`/account/vaults`)
        logger.log(res.data)
        AppState.profileVaults = res.data.map(v => new Vault(v))
        logger.log(AppState.profileVaults)
    }

}
export const vaultsService = new VaultsService()